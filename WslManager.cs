using DeepSeekAgent.ConPTY;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent;

public static class WslManager
{
    private static IntPtr _ptyHandle;
    private static Process? _process;

    private static FileStream? _inputWriter;
    private static FileStream? _outputReader;

    private static readonly object _lock = new();

    public static event Action<string>? Output;

    public static bool IsRunning => _process != null && !_process.HasExited;

    public static void Start(int width = 120, int height = 30)
    {
        lock (_lock)
        {
            if (IsRunning)
            {
                return;
            }

            var (inRead, inWrite) = PipeHelper.CreatePipe();
            var (outRead, outWrite) = PipeHelper.CreatePipe();

            var size = new COORD
            {
                X = (short)width,
                Y = (short)height
            };

            // 1. Create PTY
            int hr = ConPtyNative.CreatePseudoConsole(
                size,
                inRead,
                outWrite,
                0,
                out _ptyHandle);

            if (hr != 0)
            {
                throw new Exception($"CreatePseudoConsole failed: {hr}");
            }

            // 2. Setup STARTUPINFOEX
            var siEx = new STARTUPINFOEX();
            siEx.StartupInfo.cb = (uint)Marshal.SizeOf(siEx);

            var lpSize = IntPtr.Zero;

            ConPtyNative.InitializeProcThreadAttributeList(IntPtr.Zero, 1, 0, ref lpSize);

            siEx.lpAttributeList = Marshal.AllocHGlobal(lpSize);

            if (!ConPtyNative.InitializeProcThreadAttributeList(siEx.lpAttributeList, 1, 0, ref lpSize))
            {
                throw new Win32Exception();
            }

            if (!ConPtyNative.UpdateProcThreadAttribute(
                    siEx.lpAttributeList,
                    0,
                    (IntPtr)ConPtyNative.PROC_THREAD_ATTRIBUTE_PSEUDOCONSOLE,
                    _ptyHandle,
                    (IntPtr)IntPtr.Size,
                    IntPtr.Zero,
                    IntPtr.Zero))
            {
                throw new Win32Exception();
            }

            // 3. Create process attached to PTY
            var pi = new PROCESS_INFORMATION();

            bool success = ConPtyNative.CreateProcess(
                null,
                "wsl.exe",
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                ConPtyNative.EXTENDED_STARTUPINFO_PRESENT,
                IntPtr.Zero,
                null,
                ref siEx,
                out pi);

            if (!success)
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }

            _process = Process.GetProcessById(pi.dwProcessId);

            _inputWriter = new FileStream(inWrite, FileAccess.Write);
            _outputReader = new FileStream(outRead, FileAccess.Read);

            Task.Run(ReadLoop);
        }
    }

    private static async Task ReadLoop()
    {
        var buffer = new byte[8192];

        while (_outputReader != null)
        {
            var read = await _outputReader.ReadAsync(buffer);

            if (read > 0)
            {
                var raw = Encoding.UTF8.GetString(buffer, 0, read);

                var clean = AnsiCleaner.Strip(raw);

                Output?.Invoke(clean);
            }
        }
    }

    public static async Task WriteAsync(string input)
    {
        if (!IsRunning || _inputWriter == null)
        {
            throw new InvalidOperationException("WSL is not running");
        }

        var data = Encoding.UTF8.GetBytes(input + "\n");

        await _inputWriter.WriteAsync(data);
        await _inputWriter.FlushAsync();
    }

    public static void Stop()
    {
        lock (_lock)
        {
            if (!IsRunning)
            {
                return;
            }

            ConPtyNative.ClosePseudoConsole(_ptyHandle);

            _process?.Kill(entireProcessTree: true);
            _process?.Dispose();
            _process = null;

            _inputWriter?.Dispose();
            _outputReader?.Dispose();

            _inputWriter = null;
            _outputReader = null;
        }
    }
}
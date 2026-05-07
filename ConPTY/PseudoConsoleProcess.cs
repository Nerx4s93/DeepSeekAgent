using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.ConPTY;

public sealed class PseudoConsoleProcess : IDisposable
{
    private IntPtr _ptyHandle;
    private Process? _process;

    private FileStream? _input;
    private FileStream? _output;

    private readonly CancellationTokenSource _cts = new();

    public event Action<string>? RawOutput;
    public event Action<string>? Output;

    public bool IsRunning => _process != null && !_process.HasExited;

    public void Start(string fileName, string arguments, int width = 120, int height = 30)
    {
        var (inRead, inWrite) = PipeHelper.CreatePipe();
        var (outRead, outWrite) = PipeHelper.CreatePipe();

        var size = new COORD
        {
            X = (short)width,
            Y = (short)height
        };

        // Create PTY
        var hr = ConPtyNative.CreatePseudoConsole(size, inRead, outWrite, 0, out _ptyHandle);

        if (hr != 0)
        {
            throw new Exception($"CreatePseudoConsole failed: {hr}");
        }

        // Setup STARTUPINFOEX
        var siEx = new STARTUPINFOEX();
        siEx.StartupInfo.cb = (uint)Marshal.SizeOf(siEx);

        var lpSize = IntPtr.Zero;
        ConPtyNative.InitializeProcThreadAttributeList(IntPtr.Zero, 1, 0, ref lpSize);

        siEx.lpAttributeList = Marshal.AllocHGlobal(lpSize);

        if (!ConPtyNative.InitializeProcThreadAttributeList(siEx.lpAttributeList, 1, 0, ref lpSize))
        {
            throw new Win32Exception();
        }

        ConPtyNative.UpdateProcThreadAttribute(
            siEx.lpAttributeList,
            0,
            (IntPtr)ConPtyNative.PROC_THREAD_ATTRIBUTE_PSEUDOCONSOLE,
            _ptyHandle,
            (IntPtr)IntPtr.Size,
            IntPtr.Zero,
            IntPtr.Zero);

        // Create process attached to PTY
        var pi = new PROCESS_INFORMATION();

        bool success = ConPtyNative.CreateProcess(
            null,
            $"{fileName} {arguments}",
            IntPtr.Zero,
            IntPtr.Zero,
            false,
            ConPtyNative.EXTENDED_STARTUPINFO_PRESENT,
            IntPtr.Zero,
            null,
            ref siEx,
            out pi);

        if (!success)
            throw new Win32Exception(Marshal.GetLastWin32Error());

        _process = Process.GetProcessById(pi.dwProcessId);

        _input = new FileStream(inWrite, FileAccess.Write);
        _output = new FileStream(outRead, FileAccess.Read);

        _ = Task.Run(ReadLoop);
    }

    private async Task ReadLoop()
    {
        var buffer = new byte[8192];

        while (!_cts.IsCancellationRequested)
        {
            if (_output == null)
            {
                break;
            }

            var read = await _output.ReadAsync(buffer);

            if (read <= 0)
            {
                continue;
            }

            var text = Encoding.UTF8.GetString(buffer, 0, read);
            RawOutput?.Invoke(text);
            Output?.Invoke(AnsiCleaner.Strip(text));
        }
    }

    public async Task WriteAsync(string input)
    {
        if (!IsRunning || _input == null)
        {
            return;
        }

        var data = Encoding.UTF8.GetBytes(input + "\n");
        await _input.WriteAsync(data);
        await _input.FlushAsync();
    }

    public void Dispose()
    {
        _cts.Cancel();

        ConPtyNative.ClosePseudoConsole(_ptyHandle);

        _process?.Kill(true);
        _process?.Dispose();

        _input?.Dispose();
        _output?.Dispose();
    }
}
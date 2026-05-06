using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent;

public static class WslManager
{
    private static Process? _process;

    public static event Action<string>? OnOutput;
    public static event Action<string>? OnError;

    public static bool IsRunning => _process != null && !_process.HasExited;

    public static void Start(string distro = "", string shell = "bash")
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("WSL already running");
        }

        var psi = new ProcessStartInfo
        {
            FileName = "wsl.exe",
            Arguments = string.IsNullOrWhiteSpace(distro)
                ? shell
                : $"-d {distro} {shell}",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };

        _process = new Process { StartInfo = psi };

        _process.OutputDataReceived += (s, e) =>
        {
            if (e.Data != null)
            {
                OnOutput?.Invoke(e.Data);
            }
        };

        _process.ErrorDataReceived += (s, e) =>
        {
            if (e.Data != null)
            {
                OnError?.Invoke(e.Data);
            }
        };

        _process.Start();

        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
    }

    public static async Task SendCommandAsync(string command)
    {
        if (!IsRunning)
        {
            throw new InvalidOperationException("WSL is not running");
        }

        command = command.Replace("\r", "").Replace("\n", "");

        await _process!.StandardInput.WriteAsync(command + "\n");
        await _process.StandardInput.FlushAsync();
    }

    public static async Task StopAsync()
    {
        if (!IsRunning)
        {
            return;
        }

        await SendCommandAsync("exit");
        await _process!.WaitForExitAsync();

        _process.Dispose();
        _process = null;
    }
}
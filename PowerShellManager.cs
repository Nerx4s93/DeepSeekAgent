using DeepSeekAgent.ConPTY;
using System;
using System.Threading.Tasks;

namespace DeepSeekAgent;

public static class PowerShellManager
{
    private static PseudoConsoleProcess? _session;
    private static readonly object _lock = new();

    public static event Action<string>? Output;

    public static bool IsRunning => _session?.IsRunning == true;

    public static void StartPowerShell(int width = 120, int height = 30)
    {
        Start("powershell.exe", "", width, height);
    }

    public static void Start(string fileName, string arguments, int width = 120, int height = 30)
    {
        lock (_lock)
        {
            Stop();

            _session = new PseudoConsoleProcess();

            _session.Output += HandleOutput;
            _session.Start(fileName, arguments, width, height);
        }
    }

    public static Task WriteAsync(string input)
    {
        return _session?.WriteAsync(input)
            ?? throw new InvalidOperationException("PowerShell session is not running");
    }

    public static void Stop()
    {
        lock (_lock)
        {
            if (_session == null)
            {
                return;
            }    

            _session.Output -= HandleOutput;
            _session.Dispose();
            _session = null;
        }
    }

    private static void HandleOutput(string text)
    {
        Output?.Invoke(text);
    }
}
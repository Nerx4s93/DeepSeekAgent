using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.System;

public class RestartCommand : LocalCommand
{
    public override string Name => "RESTART";

    public override Task<string> ExecuteAsync(string payload)
    {
        switch (payload)
        {
            case "WSL":
                {
                    WslManager.Stop();
                    WslManager.StartWsl();
                    return Task.FromResult("WSL перезапущен");
                }
            case "POWERSHELL":
                {
                    PowerShellManager.Stop();
                    PowerShellManager.StartPowerShell();
                    return Task.FromResult("POWERSHELL перезапущен");
                }
            default:
                {
                    return Task.FromResult($"{payload} не найден");
                }
        }
    }
}

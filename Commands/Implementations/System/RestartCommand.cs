using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class RestartCommand : LocalCommand
{
    public RestartCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "RESTART";
    public override string ShortDescription => "перезапуск утилит при необходимости";

    public override Task<string> ExecuteAsync(string payload)
    {
        switch (payload)
        {
            case "WSL":
                {
                    Context.WSL.Dispose();
                    Context.WSL.Start("wsl.exe", "");
                    return Task.FromResult("WSL перезапущен");
                }
            case "POWERSHELL":
                {
                    Context.WSL.Dispose();
                    Context.WSL.Start("powershell.exe", "");
                    return Task.FromResult("POWERSHELL перезапущен");
                }
            default:
                {
                    return Task.FromResult($"{payload} не найден");
                }
        }
    }
}

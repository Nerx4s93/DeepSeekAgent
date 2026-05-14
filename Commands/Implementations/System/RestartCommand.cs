using DeepSeekAgent.Commands.CommandResults;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class RestartCommand : LocalCommand
{
    public RestartCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "RESTART";
    public override string ShortDescription => "перезапуск утилит при необходимости";

    public override Task<CommandResult> ExecuteAsync(string payload)
    {
        switch (payload)
        {
            case "WSL":
                {
                    Context.WSL.Dispose();
                    Context.WSL.Start("wsl.exe", "");
                    return Task.FromResult((CommandResult)new ContinueResult("WSL перезапущен"));
                }
            case "POWERSHELL":
                {
                    Context.WSL.Dispose();
                    Context.WSL.Start("powershell.exe", "");
                    return Task.FromResult((CommandResult)new ContinueResult("POWERSHELL перезапущен"));
                }
            default:
                {
                    return Task.FromResult((CommandResult)new ContinueResult($"{payload} не найден"));
                }
        }
    }
}

using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class HelpCommand : LocalCommand
{
    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "HELP";
    public override string ShortDescription => "обзор протокола выполнения команд и доп. информация";

    public override Task<string> ExecuteAsync(string payload)
    {
        return Task.FromResult(ResourcesDataLoader.GetDataText("Commands.Response.HELP.txt")!);
    }
}

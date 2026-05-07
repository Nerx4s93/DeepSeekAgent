using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class ListCommand : LocalCommand
{
    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "LIST";
    public override string ShortDescription => "список доступных команд и утилит";

    public override Task<string> ExecuteAsync(string payload)
    {
        return Task.FromResult(ResourcesDataLoader.GetDataText("Commands.Response.LIST.txt")!);
    }
}
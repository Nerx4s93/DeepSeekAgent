using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.System;

public class ListCommand : LocalCommand
{
    public override string Name => "LIST";

    public override Task<string> ExecuteAsync(string payload)
    {
        return Task.FromResult(ResourcesDataLoader.GetDataText("Commands.Response.LIST.txt")!);
    }
}
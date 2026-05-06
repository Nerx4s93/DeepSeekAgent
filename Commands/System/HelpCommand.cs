using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.System;

public class HelpCommand : LocalCommand
{
    public override string Name => "HELP";

    public override Task<string> ExecuteAsync(string payload)
    {
        return Task.FromResult(ResourcesDataLoader.GetDataText("Commands.Response.HELP.txt")!);
    }
}

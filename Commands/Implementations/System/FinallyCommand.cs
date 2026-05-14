using DeepSeekAgent.Commands.CommandResults;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class FinallyCommand : LocalCommand
{
    public FinallyCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";

    public override string Name => "FINALLY";

    public override string ShortDescription => "останавливает цикл выполнения агента";

    public override Task<CommandResult> ExecuteAsync(string payload)
    {
        return Task.FromResult((CommandResult)new FinallyResult());
    }
}

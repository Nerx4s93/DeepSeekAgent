using DeepSeekAgent.Commands.CommandResults;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations;

public class WaitCommand : LocalCommand
{
    public WaitCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "TOOLS";
    public override string Name => "WAIT";
    public override string ShortDescription => "задержка выполнения";

    public override async Task<CommandResult> ExecuteAsync(string payload)
    {
        var time = int.Parse(payload);
        await Task.Delay(time);

        var resultText = """
           RESPONSE WAIT
           END RESPONSE
           """;

        var result = new ContinueResult(resultText);
        return (CommandResult)result;
    }
}

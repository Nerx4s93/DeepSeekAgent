using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class WaitCommand : LocalCommand
{
    public override string Name => "WAIT";

    public override async Task<string> ExecuteAsync(string input)
    {
        var time = int.Parse(input);
        await Task.Delay(time);

        return """
           RESPONSE WAIT
           END RESPONSE
           """;
    }
}

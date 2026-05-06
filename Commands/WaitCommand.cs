using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class WaitCommand : LocalCommand
{
    public override string Name => "WAIT";

    public override async Task<string> ExecuteAsync(string payload)
    {
        var time = int.Parse(payload);
        await Task.Delay(time);

        return """
           RESPONSE WAIT
           END RESPONSE
           """;
    }
}

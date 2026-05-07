using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations;

public class WSLCommand : LocalCommand
{
    private const int TimeoutMs = 1500;

    public WSLCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "TOOLS";
    public override string Name => "WSL";
    public override string ShortDescription => "выполнение Linux-команд через WSL";

    public override async Task<string> ExecuteAsync(string payload)
    {
        var stringBuilder = new StringBuilder();
        var tcs = new TaskCompletionSource<string>();

        Timer? timer = null;

        void ResetTimer()
        {
            timer?.Change(TimeoutMs, Timeout.Infinite);
        }

        void OnOutput(string data)
        {
            stringBuilder.Append(data);
            ResetTimer();
        }

        try
        {
            Context.WSL.Output += OnOutput;

            timer = new Timer(_ =>
            {
                tcs.TrySetResult(stringBuilder.ToString());
            });

            ResetTimer();

            await Context.WSL.WriteAsync(payload);

            var executeResult = await tcs.Task;

            return $"""
            RESPONSE WSL
            {executeResult.Trim()}
            END RESPONSE
            """;
        }
        finally
        {
            Context.WSL.Output -= OnOutput;
            timer?.Dispose();
        }
    }
}
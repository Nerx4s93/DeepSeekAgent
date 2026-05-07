using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class WSLCommand : LocalCommand
{
    public override string Group => "TOOLS";
    public override string Name => "WSL";
    public override string ShortDescription => "выполнение Linux-команд через WSL";


    private const int TimeoutMs = 1500;

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
            WslManager.Output += OnOutput;

            timer = new Timer(_ =>
            {
                tcs.TrySetResult(stringBuilder.ToString());
            });

            ResetTimer();

            await WslManager.WriteAsync(payload);

            var executeResult = await tcs.Task;

            return $"""
            RESPONSE WSL
            {executeResult.Trim()}
            END RESPONSE
            """;
        }
        finally
        {
            WslManager.Output -= OnOutput;
            timer?.Dispose();
        }
    }
}
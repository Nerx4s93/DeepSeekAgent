using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class WSLCommand : LocalCommand
{
    public override string Name => "WSL";

    private const int TimeoutMs = 1500;

    public override async Task<string> ExecuteAsync(string input)
    {
        var sb = new StringBuilder();
        var tcs = new TaskCompletionSource<string>();

        Timer? timer = null;

        void ResetTimer()
        {
            timer?.Change(TimeoutMs, Timeout.Infinite);
        }

        void OnOutput(string data)
        {
            sb.Append(data);
            ResetTimer();
        }

        try
        {
            WslManager.Output += OnOutput;

            timer = new Timer(_ =>
            {
                tcs.TrySetResult(sb.ToString());
            });

            ResetTimer();

            await WslManager.WriteAsync(input);

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
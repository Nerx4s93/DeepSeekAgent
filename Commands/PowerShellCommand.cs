using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class PowerShellCommand : LocalCommand
{
    public override string Name => "POWERSHELL";

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
            PowerShellManager.Output += OnOutput;

            timer = new Timer(_ =>
            {
                tcs.TrySetResult(stringBuilder.ToString());
            });

            ResetTimer();

            await PowerShellManager.WriteAsync(payload + "\r");

            var executeResult = await tcs.Task;

            return $"""
            RESPONSE POWERSHELL
            {executeResult.Trim()}
            END RESPONSE
            """;
        }
        finally
        {
            PowerShellManager.Output -= OnOutput;
            timer?.Dispose();
        }
    }
}
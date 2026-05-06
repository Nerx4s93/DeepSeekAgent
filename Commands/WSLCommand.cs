using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class WSLCommand : LocalCommand
{
    public override string Name => "WSL";

    public override string Description => "Выполнение WSL команд.";

    private const int TimeoutMs = 1500;

    public override async Task<string> ExecuteAsync(string input)
    {
        var stringBuilder = new StringBuilder();
        var tcs = new TaskCompletionSource<string>();
        using var cts = new CancellationTokenSource();

        Timer? timer = null;

        void ResetTimer()
        {
            timer?.Change(TimeoutMs, Timeout.Infinite);
        }

        void OnOut(string data)
        {
            stringBuilder.AppendLine(data);
            ResetTimer();
        }

        void OnErr(string data)
        {
            stringBuilder.AppendLine(data);
            ResetTimer();
        }

        try
        {
            WslManager.OnOutput += OnOut;
            WslManager.OnError += OnErr;

            timer = new Timer(_ =>
            {
                tcs.TrySetResult(stringBuilder.ToString());
            });

            ResetTimer();

            await WslManager.SendCommandAsync(input);

            var result = await tcs.Task;

            return result;
        }
        finally
        {
            WslManager.OnOutput -= OnOut;
            WslManager.OnError -= OnErr;

            timer?.Dispose();
            cts.Cancel();
        }
    }
}

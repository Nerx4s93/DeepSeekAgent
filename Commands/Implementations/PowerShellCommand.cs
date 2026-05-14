using DeepSeekAgent.Commands.CommandResults;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations;

public class PowerShellCommand : LocalCommand
{
    private const int TimeoutMs = 1500;

    public PowerShellCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "TOOLS";
    public override string Name => "POWERSHELL";
    public override string ShortDescription => "выполнение Windows-команд через PowerShell";

    public override async Task<CommandResult> ExecuteAsync(string payload)
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
            Context.PowerShell.Output += OnOutput;

            timer = new Timer(_ =>
            {
                tcs.TrySetResult(stringBuilder.ToString());
            });

            ResetTimer();

            await Context.PowerShell.WriteAsync(payload + "\r");

            var executeResult = await tcs.Task;

            var resultText = $"""
            RESPONSE POWERSHELL
            {executeResult.Trim()}
            END RESPONSE
            """;

            var result = new ContinueResult(resultText);
            return (CommandResult)result;
        }
        finally
        {
            Context.PowerShell.Output -= OnOutput;
            timer?.Dispose();
        }
    }
}
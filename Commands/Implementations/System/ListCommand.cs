using DeepSeekAgent.Commands.CommandResults;
using System.Linq;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class ListCommand : LocalCommand
{
    public ListCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "LIST";
    public override string ShortDescription => "список доступных команд и утилит";

    public override Task<CommandResult> ExecuteAsync(string payload)
    {
        if (Context.CommandRegistry == null)
        {
            return Task.FromResult(
                (CommandResult)
                new ContinueResult("Context.CommandRegistry == null. Команда не работает."));
        }

        var commands = Context.CommandRegistry.GetCommands();
        var groups = commands.GroupBy(c => c.Group);

        var resultText = "";

        foreach (var group in groups)
        {
            resultText += $"{group.Key}:\n";

            foreach (var cmd in group)
            {
                resultText += $" - {cmd.Name} : {cmd.ShortDescription}\n";
            }

            resultText += "\n";
        }

        var result = new ContinueResult(resultText);
        return Task.FromResult((CommandResult)result);
    }
}
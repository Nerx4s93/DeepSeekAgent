using System.Linq;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class ListCommand : LocalCommand
{
    public ListCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "LIST";
    public override string ShortDescription => "список доступных команд и утилит";

    public override Task<string> ExecuteAsync(string payload)
    {
        if (Context.CommandRegistry == null)
        {
            return Task.FromResult("Context.CommandRegistry == null. Команда не работает.");
        }

        var commands = Context.CommandRegistry.GetCommands();
        var groups = commands.GroupBy(c => c.Group);

        var response = "";

        foreach (var group in groups)
        {
            response += $"{group.Key}:\n";

            foreach (var cmd in group)
            {
                response += $" - {cmd.Name} : {cmd.ShortDescription}\n";
            }

            response += "\n";
        }

        return Task.FromResult(response);
    }
}
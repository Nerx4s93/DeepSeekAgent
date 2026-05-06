using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DeepSeekAgent;

public class CommandRegistry
{
    private readonly Dictionary<string, DualCommand> _commands = new(StringComparer.OrdinalIgnoreCase);

    public CommandRegistry()
    {
        var commandType = typeof(DualCommand);
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && commandType.IsAssignableFrom(t));

        foreach (var type in types)
        {
            var command = (DualCommand)Activator.CreateInstance(type)!;
            _commands.Add(command.Name, command);
        }
    }

    public DualCommand? GetCommand(string name) =>
        _commands.TryGetValue(name, out var cmd) ? cmd : null;

    public string GetToolsDescription() =>
        string.Join("\n", _commands.Values.Select(c => $"{c.Name}: {c.Description}"));
}
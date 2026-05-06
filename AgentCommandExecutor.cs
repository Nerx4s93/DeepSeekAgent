using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent;

internal class AgentCommandExecutor
{
    private readonly CommandRegistry _commandRegistry;

    public AgentCommandExecutor(CommandRegistry commandRegistry)
    {
        _commandRegistry = commandRegistry;
    }

    public async Task<string> ExecuteCommandsAsync(List<AgentCommand> commands)
    {
        var stringBuilder = new StringBuilder();

        foreach (var command in commands)
        {
            var tool = _commandRegistry.GetCommand(command.ToolName);

            if (tool == null)
            {
                stringBuilder.AppendLine($"RESPONSE {command.ToolName}");
                stringBuilder.AppendLine($"Error: Инструмент '{command.ToolName}' не найден в реестре.");
                stringBuilder.AppendLine($"END RESPONSE");
                continue;
            }

            try
            {
                var result = await tool.ExecuteAsync(command.Payload);
                stringBuilder.AppendLine($"RESPONSE {command.ToolName}");
                stringBuilder.AppendLine(result);
                stringBuilder.AppendLine($"END RESPONSE");
            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine($"RESPONSE {command.ToolName}");
                stringBuilder.AppendLine($"Critical Error during execution: {ex.Message}");
                stringBuilder.AppendLine($"END RESPONSE");
            }
        }

        return stringBuilder.ToString();
    }
}

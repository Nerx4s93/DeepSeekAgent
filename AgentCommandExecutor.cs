using DeepSeekAgent.Commands;
using DeepSeekAgent.Commands.CommandResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent;

public class AgentCommandExecutor
{
    private readonly CommandRegistry _commandRegistry;

    public AgentCommandExecutor(CommandRegistry commandRegistry)
    {
        _commandRegistry = commandRegistry;
    }

    public async Task<(string response, bool end)> ExecuteCommandsAsync(List<AgentCommand> commands)
    {
        var stringBuilder = new StringBuilder();
        var end = false;

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

                if (result is ContinueResult continueResult)
                {
                    stringBuilder.AppendLine(continueResult.Message);
                }
                else if (result is FinallyResult finallyResult)
                {
                    end = true;
                }
            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine($"RESPONSE {command.ToolName}");
                stringBuilder.AppendLine($"Critical Error during execution: {ex.Message}");
                stringBuilder.AppendLine($"END RESPONSE");
            }
        }

        return (stringBuilder.ToString(), end);
    }
}

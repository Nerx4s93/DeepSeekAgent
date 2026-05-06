using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeepSeekAgent;

internal class AgentCommandParser
{
    private static readonly Regex BlockRegex = new(
        @"COMMAND\s+(?<tool>\w+)\s*\r?\n(?<payload>.*?)\r?\nEND\s+\k<tool>",
        RegexOptions.Compiled | RegexOptions.Singleline);

    private static readonly Regex InlineRegex = new(
        @"COMMAND\s+(?<tool>\w+)\s+(?<payload>[^\r\n]+)",
        RegexOptions.Compiled);

    public List<AgentCommand> Parse(string text)
    {
        var commands = new List<AgentCommand>();

        foreach (Match match in BlockRegex.Matches(text))
        {
            commands.Add(new AgentCommand
            {
                ToolName = match.Groups["tool"].Value.ToUpper(),
                Payload = match.Groups["payload"].Value.Trim()
            });
        }
        foreach (Match match in InlineRegex.Matches(text))
        {
            if (text.Contains("END " + match.Groups["tool"].Value))
            {
                continue;
            }    

            commands.Add(new AgentCommand
            {
                ToolName = match.Groups["tool"].Value.ToUpper(),
                Payload = match.Groups["payload"].Value.Trim()
            });
        }

        return commands;
    }
}
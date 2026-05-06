using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeepSeekAgent;

internal class AgentCommandParser
{
    private static readonly Regex CommandRegex = new Regex(
        @"COMMAND\s+(?<tool>\w+)\s+(?<s>.*?)\s+END\s+\k<tool>",
        RegexOptions.Compiled | RegexOptions.Singleline);

    public List<AgentCommand> Parse(string text)
    {
        var commands = new List<AgentCommand>();
        var matches = CommandRegex.Matches(text);

        foreach (Match match in matches)
        {
            commands.Add(new AgentCommand
            {
                ToolName = match.Groups["tool"].Value.ToUpper(),
                Payload = match.Groups["s"].Value.Trim()
            });
        }

        return commands;
    }
}
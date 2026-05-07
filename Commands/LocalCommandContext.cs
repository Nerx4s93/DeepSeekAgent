using DeepSeekAgent.ConPTY;

namespace DeepSeekAgent.Commands;

public class LocalCommandContext
{
    public required PseudoConsoleProcess PowerShell { get; init; }
    public required PseudoConsoleProcess WSL { get; init; }
}
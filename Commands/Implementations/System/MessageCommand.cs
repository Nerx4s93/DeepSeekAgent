using DeepSeekAgent.Commands.CommandResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class MessageCommand : LocalCommand
{
    public MessageCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "MESSAGE";
    public override string ShortDescription => "Отправить сообщение человеку";

    public override Task<CommandResult> ExecuteAsync(string payload)
    {
        return Task.FromResult((CommandResult)new ContinueResult(""));
    }
}

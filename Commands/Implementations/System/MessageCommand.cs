using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

internal class MessageCommand : LocalCommand
{
    public MessageCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "MESSAGE";
    public override string ShortDescription => "Отправить сообщение человеку";

    public override Task<string> ExecuteAsync(string payload)
    {
        return (Task<string>)Task.CompletedTask;
    }
}

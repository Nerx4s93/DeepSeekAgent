using DeepSeekAgent.Commands.CommandResults;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

public class InfoCommand : LocalCommand
{
    public InfoCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "INFO";
    public override string ShortDescription => "подробная информация о команде или утилите";

    public override Task<CommandResult> ExecuteAsync(string payload)
    {
        var path = $"Commands.Info.{payload}.md";
        var commandInfo = ResourcesDataLoader.GetDataText(path);

        var resultText = commandInfo ?? $"Команда {payload} не существует или у неё отсутствует описание.";
        var result = new ContinueResult(resultText);
        return Task.FromResult((CommandResult)result);
    }
}

using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations.System;

internal class InfoCommand : LocalCommand
{
    public InfoCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "SYSTEM COMMANDS";
    public override string Name => "INFO";
    public override string ShortDescription => "подробная информация о команде или утилите";

    public override Task<string> ExecuteAsync(string payload)
    {
        var path = $"Commands.Info.{payload}.md";
        var commandInfo = ResourcesDataLoader.GetDataText(path);

        return Task.FromResult(commandInfo ?? $"Команда {payload} не существует или у неё отсутствует описание.");
    }
}

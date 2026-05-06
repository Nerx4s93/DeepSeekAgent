using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.System;

internal class InfoCommand : LocalCommand
{
    public override string Name => "INFO";

    public override Task<string> ExecuteAsync(string payload)
    {
        var path = $"Commands.Info.{payload}.txt";
        var commandInfo = ResourcesDataLoader.GetDataText(path);

        return Task.FromResult(commandInfo ?? $"Команда {payload} не существует или у неё отсутствует описание.");
    }
}

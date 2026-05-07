using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public abstract class LocalCommand
{
    public LocalCommandContext Context { get; }

    protected LocalCommand(LocalCommandContext context)
    {
        Context = context;
    }

    public abstract string Group { get; }
    public abstract string Name { get; }
    public abstract string ShortDescription { get; }

    public abstract Task<string> ExecuteAsync(string payload);
}
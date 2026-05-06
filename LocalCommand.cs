using System.Threading.Tasks;

namespace DeepSeekAgent;

public abstract class LocalCommand
{
    public abstract string Name { get; }
    public abstract Task<string> ExecuteAsync(string input);
}
using System.Threading.Tasks;

namespace DeepSeekAgent;

public abstract class DualCommand
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract Task<string> ExecuteAsync(string input);
}
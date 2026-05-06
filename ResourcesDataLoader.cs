using System.IO;
using System.Reflection;

namespace DeepSeekAgent;

internal static class ResourcesDataLoader
{
    public static Stream? GetDataStream(string path)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"DeepSeekAgent.Resources.{path}";
        var stream = assembly.GetManifestResourceStream(resourceName);
        return stream;
    }

    public static string? GetDataText(string path)
    {
        var stream = GetDataStream(path);

        if (stream == null)
        {
            return null;
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}

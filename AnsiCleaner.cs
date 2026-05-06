using System.Text.RegularExpressions;

namespace DeepSeekAgent;

public static class AnsiCleaner
{
    private static readonly Regex AnsiRegex =
        new(@"\x1B\[[0-9;?]*[a-zA-Z]", RegexOptions.Compiled);

    public static string Strip(string input)
    {
        return AnsiRegex.Replace(input, "");
    }
}
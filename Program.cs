using System;
using System.IO;
using System.Windows.Forms;

using DeepSeekAgent.GUI;

namespace DeepSeekAgent;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var apiKey = ReadFile("apikey.txt");
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain(apiKey));
    }

    private static string ReadFile(string file)
    {
        if (!File.Exists(file))
        {
            return "";
        }

        return File.ReadAllText(file);
    }
}
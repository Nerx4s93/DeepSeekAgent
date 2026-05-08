using System;
using System.Windows.Forms;

using DeepSeekAgent.GUI;

namespace DeepSeekAgent;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}
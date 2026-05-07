using DeepSeekAgent.Commands;
using DeepSeekAgent.ConPTY;
using DeepSeekAPI;
using DeepSeekAPI.Exceptions;
using DeepSeekAPI.Models.Chat;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepSeekAgent.UI;

public class AgentManager : SideTabControl
{
    public async Task AddDeepSeekClient(string token)
    {
        var deepSeekClient = new DeepSeekClient(token);

        var chatSettings = new ChatSettings()
        {
            ModelType = ModelType.Expert,
            Search = false,
            Thinking = false
        };

        var wsl = new PseudoConsoleProcess();
        var powerShell = new PseudoConsoleProcess();

        wsl.Start("wsl.exe", "");
        powerShell.Start("powershell.exe", "");

        var localCommandContext = new LocalCommandContext()
        {
            WSL = wsl,
            PowerShell = powerShell
        };

        var commandRegistry = new CommandRegistry(localCommandContext);
        var agentCommandParser = new AgentCommandParser();
        var agentCommandExecutor = new AgentCommandExecutor(commandRegistry);



        var agentChat = new AgentChat(
            localCommandContext,
            commandRegistry,
            agentCommandParser,
            agentCommandExecutor,
            deepSeekClient,
            chatSettings);

        var tab = AddTab("deepseek");
        if (InvokeRequired)
        {
            Invoke(() => tab.Content.Controls.Add(agentChat));
        }
        else
        {
            tab.Content.Controls.Add(agentChat);
        }
    }
}

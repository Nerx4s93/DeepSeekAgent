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

        var userProfile = await deepSeekClient.GetUserProfileAsync();

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

        var tab = AddTab(userProfile.Email);
        tab.Tag = agentChat;
        if (InvokeRequired)
        {
            Invoke(() => tab.Content.Controls.Add(agentChat));
        }
        else
        {
            tab.Content.Controls.Add(agentChat);
        }
    }

    public LocalCommandContext? GetLocalCommandContextSelectedTab()
    {
        if (SelectedTab != null &&
            SelectedTab.Tag != null &&
            SelectedTab.Tag is AgentChat agentChat)
        {
            return agentChat.LocalCommandContext;
        }

        return null;
    }


    public async Task ClearHistorySelectedTab()
    {
        if (SelectedTab != null &&
            SelectedTab.Tag != null &&
            SelectedTab.Tag is AgentChat agentChat)
        {
            await agentChat.ClearHistory();
        }
    }

    public ChatSettings? GetChatSettigs()
    {
        if (SelectedTab != null &&
            SelectedTab.Tag != null &&
            SelectedTab.Tag is AgentChat agentChat)
        {
            return agentChat.ChatSettings;
        }

        return null;
    }

    public void DeepSeekToggleThinking()
    {
        if (SelectedTab != null &&
            SelectedTab.Tag != null &&
            SelectedTab.Tag is AgentChat agentChat)
        {
            agentChat.ChatSettings.Thinking = !agentChat.ChatSettings.Thinking;
        }
    }

    public void DeepSeekToggleSearch()
    {
        if (SelectedTab != null &&
            SelectedTab.Tag != null &&
            SelectedTab.Tag is AgentChat agentChat)
        {
            agentChat.ChatSettings.Search = !agentChat.ChatSettings.Search;
        }
    }

    public void DeepSeekSwitchMode()
    {
        if (SelectedTab != null &&
            SelectedTab.Tag != null &&
            SelectedTab.Tag is AgentChat agentChat)
        {
            agentChat.ChatSettings.ModelType =
                agentChat.ChatSettings.ModelType == ModelType.Default ?
                ModelType.Expert : ModelType.Default;
        }
    }
}

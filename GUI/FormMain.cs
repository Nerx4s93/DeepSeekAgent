using DeepSeekAPI.Exceptions;
using DeepSeekAPI.Models.Chat;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormMain : Form
{
    public FormMain(string apiKey)
    {
        InitializeComponent();
    }

    private async void FormMain_Shown(object sender, EventArgs e)
    {
        try
        {
            var token = File.ReadAllText("apikey.txt");
            await agentManager.AddDeepSeekClient(token);
            UpdateChatSettingsInfo();
        }
        catch (AuthenticationError)
        {
            MessageBox.Show(
                "Не удалось создать DeepSeekClient",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
    }

    #region Файл

    private async void buttonClearHistory_Click(object sender, EventArgs e)
    {
        await agentManager.ClearHistorySelectedTab();
    }

    #endregion

    #region Настройки

    private async void buttonChangeApiKey_Click(object sender, EventArgs e)
    {
        await ChangeApiKeyAsync();
    }

    private async Task ChangeApiKeyAsync()
    {
        var apiKey = Interaction.InputBox(
            "Введите новый api key.\nЭто очистит всю предыдущую историю запросов!",
            "Новый api key",
            ""
        );

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return;
        }

        try
        {

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonDeepSeekToggleThinking_Click(object sender, EventArgs e)
    {
        if (agentManager.SelectedTab == null)
        {
            return;
        }

        agentManager.DeepSeekToggleThinking();
        UpdateChatSettingsInfo();
    }

    private void buttonDeepSeekToggleSearch_Click(object sender, EventArgs e)
    {
        if (agentManager.SelectedTab == null)
        {
            return;
        }

        agentManager.DeepSeekToggleSearch();
        UpdateChatSettingsInfo();
    }

    private void buttonDeepSeekToggleSwichMode_Click(object sender, EventArgs e)
    {
        if (agentManager.SelectedTab == null)
        {
            return;
        }

        agentManager.DeepSeekSwitchMode();
        UpdateChatSettingsInfo();
    }

    private void UpdateChatSettingsInfo()
    {
        var chatSettings = agentManager.GetChatSettigs();

        if (chatSettings == null)
        {
            return;
        }

        buttonDeepSeekToggleThinking.Text = "Thinking: " +
            (chatSettings.Thinking ? "Enable" : "Disable");
        buttonDeepSeekToggleSearch.Text = "Search: " +
            (chatSettings.Search ? "Enable" : "Disable");
        buttonDeepSeekToggleSwichMode.Text = "Model: " +
            (chatSettings.ModelType == ModelType.Default ? "Default" : "Expert");
    }

    #endregion

    #region Инструменты

    private void buttonShowWSL_Click(object sender, EventArgs e)
    {
        var context = agentManager.GetLocalCommandContextSelectedTab();

        if (context == null)
        {
            return;
        }

        var wsl = context.WSL;
        new FormPseudoConsole(wsl).Show();
    }

    private void buttonShowPowerShell_Click(object sender, EventArgs e)
    {
        var context = agentManager.GetLocalCommandContextSelectedTab();

        if (context == null)
        {
            return;
        }

        var powerShell = context.PowerShell;
        new FormPseudoConsole(powerShell).Show();
    }

    #endregion
}
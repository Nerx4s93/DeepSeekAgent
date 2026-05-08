using DeepSeekAgent.Models;
using DeepSeekAPI;
using DeepSeekAPI.Exceptions;
using DeepSeekAPI.Models.Chat;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
    }

    private async void FormMain_Shown(object sender, EventArgs e)
    {
        try
        {
            var context = new AppDatabaseContext();

            var tasks = new List<Task>();

            foreach (var token in context.DeepSeekTokens)
            {
                var task = agentManager.AddDeepSeekClient(token.Value);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

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

    private async void buttonAddAgent_Click(object sender, EventArgs e)
    {
        await AddAgentAsync();
    }

    private async Task AddAgentAsync()
    {
        var token = Interaction.InputBox(
            "Введите новый api key.\nЭто очистит всю предыдущую историю запросов!",
            "Новый api key",
            ""
        );

        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        try
        {
            var context = new AppDatabaseContext();

            if (context.DeepSeekTokens.Any(t => t.Value == token))
            {
                MessageBox.Show(
                    "Агент с такоим токеном уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var deepSeekClient = new DeepSeekClient(token);
            await deepSeekClient.GetUserProfileAsync();

            context.DeepSeekTokens.Add(new DeepSeekToken() { Value = token });
            await context.SaveChangesAsync();

            await agentManager.AddDeepSeekClient(token);
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

    private void agentManager_DataContextChanged(object sender, EventArgs e)
    {
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
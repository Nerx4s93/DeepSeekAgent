using DeepSeekAPI.Exceptions;
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

    #endregion

    #region Инструменты

    private void buttonShowWSL_Click(object sender, EventArgs e)
    {
        //new FormPseudoConsole(_localCommandContext.WSL).Show();
    }

    private void buttonShowPowerShell_Click(object sender, EventArgs e)
    {
        //new FormPseudoConsole(_localCommandContext.PowerShell).Show();
    }

    #endregion
}
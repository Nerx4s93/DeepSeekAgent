using DeepSeekAPI;
using DeepSeekAPI.Exceptions;
using DeepSeekAPI.Models.Chat;
using DeepSeekAPI.Streaming;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormMain : Form
{
    private CommandRegistry _commandRegistry = null!;
    private AgentCommandParser _agentCommandParser = null!;
    private AgentCommandExecutor _agentCommandExecutor = null!;
    private DeepSeekClient _deepSeekClient = null!;

    private ChatSettings _chatSettings = null!;

    private ChatSession _chatSession = null!;
    private long? _lastMessageId = null;

    public FormMain(string apiKey)
    {
        InitializeComponent();
        _ = Init(apiKey);
    }

    private async Task Init(string apiKey)
    {
        _commandRegistry = new CommandRegistry();
        _agentCommandParser = new AgentCommandParser();
        _agentCommandExecutor = new AgentCommandExecutor(_commandRegistry);
        try
        {
            _deepSeekClient = new DeepSeekClient(apiKey);
            _chatSession = await _deepSeekClient.CreateChatSession();

            _chatSettings = new ChatSettings()
            {
                ModelType = ModelType.Expert,
                Search = false,
                Thinking = false
            };

            richTextBoxPromt.ReadOnly = false;
        }
        catch (AuthenticationError)
        {
            MessageBox.Show(
                "Вставьте свой токен перед началом работы.",
                "Начало работы",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

    #region Файл

    private async void buttonClearHistory_Click(object sender, EventArgs e)
    {
        richTextBoxLogs.Clear();
        await CreateChatSession();
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
            _deepSeekClient = new DeepSeekClient(apiKey);
            await CreateChatSession();

            File.WriteAllText("apikey.txt", apiKey);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #endregion

    #region Инструменты

    private void buttonWSL_Click(object sender, EventArgs e)
    {
        new FormWSL().Show();
    }

    #endregion

    private async void richTextBoxPromt_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && e.Shift == false)
        {
            var task = richTextBoxPromt.Text;
            richTextBoxPromt.Clear();
            var basePromt = ResourcesDataLoader.GetDataText("BasePromt.txt");

            var promt =
                (_lastMessageId == null ? basePromt + "\n\n" : "") +
                "Задача пользователя:\n" + task;

            richTextBoxPromt.ReadOnly = true;

            await Task.Run(async () =>
            {
                if (_lastMessageId != null)
                {
                    richTextBoxLogs.LogLine();
                    richTextBoxLogs.LogLine();
                }

                richTextBoxLogs.LogLine("[TASK]:", Color.FromArgb(120, 220, 120));
                richTextBoxLogs.LogLine(task.TrimEnd());
                richTextBoxLogs.LogLine();

                await StartHandle(promt);
            });

            richTextBoxPromt.ReadOnly = false;
        }
    }

    private async Task<bool> CreateChatSession()
    {
        try
        {
            _chatSession = await _deepSeekClient.CreateChatSession();
            _lastMessageId = null;
            richTextBoxPromt.ReadOnly = false;

            return true;
        }
        catch
        {
            return false;
        }
    }

    private async Task StartHandle(string promt)
    {
        try
        {
            var response = await SendMessage(_chatSession, promt, _chatSettings, _lastMessageId);

            while (true)
            {
                _lastMessageId = response.messageId;
                var commands = _agentCommandParser.Parse(response.text);

                if (response.text.Contains("FINAL_RESULT"))
                {
                    break;
                }

                if (commands.Count > 0)
                {
                    var resultsForAi = await _agentCommandExecutor.ExecuteCommandsAsync(commands);

                    richTextBoxLogs.LogLine("");
                    richTextBoxLogs.LogLine("");
                    richTextBoxLogs.LogLine("[COMMANDS]:", Color.FromArgb(120, 170, 255));
                    richTextBoxLogs.LogLine(resultsForAi);

                    while (true)
                    {
                        try
                        {
                            response = await SendMessage(_chatSession, resultsForAi, _chatSettings, _lastMessageId);
                            break;
                        }
                        catch (RateLimitError)
                        {
                            richTextBoxLogs.LogLine("Rate limit exeption.", Color.Yellow);
                            richTextBoxLogs.Log("Wait to send message again", Color.Yellow);

                            for (var i = 0; i < 3; i++)
                            {
                                await Task.Delay(2500);
                                richTextBoxLogs.Log(".", Color.Yellow);
                            }

                            richTextBoxLogs.LogLine();
                            richTextBoxLogs.LogLine();
                        }
                    }
                }
                else
                {
                    richTextBoxLogs.LogLine("\n\n[Error]: ИИ выдал ответ без команд и не завершил задачу.", Color.Red);
                    break;
                }
            }

        }
        catch (Exception ex)
        {
            richTextBoxLogs.LogLine(ex.ToString(), Color.Red);
        }
    }

    private async Task<(long? messageId, string text)> SendMessage(
        ChatSession chatSession,
        string prompt,
        ChatSettings chatSettings,
        long? parentMessage = null)
    {
        richTextBoxLogs.LogLine("[DEEPSEEK]:", Color.FromArgb(220, 80, 80));

        long? messageId = null;
        var text = string.Empty;

        await foreach (var deepSeekEvent in _deepSeekClient.ChatCompletion(
            chatSession,
            prompt,
            chatSettings,
            parentMessage))
        {
            if (deepSeekEvent is MessageInitEvent messageInitEvent)
            {
                richTextBoxLogs.Log(messageInitEvent.Content ?? "");
                messageId = messageInitEvent.MessageId;
                text += messageInitEvent.Content;
            }
            else if (deepSeekEvent is PatchEvent patchEvent)
            {
                if (patchEvent.Path != "response/fragments/-1/content")
                {
                    continue;
                }

                richTextBoxLogs.Log(patchEvent.Value);
                text += patchEvent.Value;
            }
            else if (deepSeekEvent is TextEvent textEvent)
            {
                richTextBoxLogs.Log(textEvent.Text);
                text += textEvent.Text;
            }
        }

        return (messageId, text);
    }
}

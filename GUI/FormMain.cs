using DeepSeekAPI;
using DeepSeekAPI.Exceptions;
using DeepSeekAPI.Models.Chat;
using DeepSeekAPI.Streaming;
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
    private CommandRegistry _commandRegistry = null!;
    private AgentCommandParser _agentCommandParser = null!;
    private AgentCommandExecutor _agentCommandExecutor = null!;
    private DeepSeekClient _deepSeekClient = null!;

    private ChatSettings _chatSettings = null!;

    private bool _sendBasePromt = true;
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

            buttonStart.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonWSL_Click(object sender, EventArgs e)
    {
        new FormWSL().Show();
    }

    private async void buttonClearHistory_Click(object sender, EventArgs e)
    {
        Console.Clear();
        await CreateChatSession();
    }

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
            listViewTasks.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void buttonStart_Click(object sender, EventArgs e)
    {
        var startForm = new FormStartPromt();
        var dialogResult = startForm.ShowDialog();

        if (dialogResult == DialogResult.OK)
        {
            var task = startForm.Result;
            var basePromt = ResourcesDataLoader.GetDataText("BasePromt.txt");

            var promt =
                (_sendBasePromt ? basePromt + "\n\n" : "") +
                "Задача пользователя:\n" + task;

            _sendBasePromt = false;
            buttonStart.Enabled = false;

            await Task.Run(async () =>
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[TASK]:");
                Console.ResetColor();
                Console.WriteLine(task.TrimEnd());
                Console.WriteLine();

                await StartHandle(promt);
            });

            buttonStart.Enabled = true;
        }
    }

    private async Task<bool> CreateChatSession()
    {
        try
        {
            _chatSession = await _deepSeekClient.CreateChatSession();
            _lastMessageId = null;
            buttonStart.Enabled = true;

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

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("[COMMANDS]:");
                    Console.ResetColor();
                    Console.WriteLine(resultsForAi);

                    response = await SendMessage(_chatSession, resultsForAi, _chatSettings, _lastMessageId);
                }
                else
                {
                    Console.WriteLine("\n\n[Error]: ИИ выдал ответ без команд и не завершил задачу.");
                    break;
                }
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task<(long? messageId, string text)> SendMessage(
        ChatSession chatSession,
        string prompt,
        ChatSettings chatSettings,
        long? parentMessage = null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[DEEPSEEK]:");
        Console.ResetColor();

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
                Console.Write(messageInitEvent.Content);
                messageId = messageInitEvent.MessageId;
                text += messageInitEvent.Content;
            }
            else if (deepSeekEvent is PatchEvent patchEvent)
            {
                if (patchEvent.Path != "response/fragments/-1/content")
                {
                    continue;
                }

                Console.Write(patchEvent.Value);
                text += patchEvent.Value;
            }
            else if (deepSeekEvent is TextEvent textEvent)
            {
                Console.Write(textEvent.Text);
                text += textEvent.Text;
            }
        }

        return (messageId, text);
    }
}

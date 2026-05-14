using DeepSeekAgent.Commands;
using DeepSeekAPI;
using DeepSeekAPI.Exceptions;
using DeepSeekAPI.Models.Chat;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepSeekAgent.UI;

[ToolboxItem(false)]
public partial class AgentChat : UserControl
{
    private readonly Color TASK_COLOR = Color.FromArgb(120, 220, 120);
    private readonly Color COMMANDS_COLOR = Color.FromArgb(120, 170, 255);
    private readonly Color DEEPSEEK_COLOR = Color.FromArgb(220, 80, 80);
    private readonly Color API_ERROR_COLOR = Color.FromArgb(220, 190, 80);

    private readonly LocalCommandContext _localCommandContext;
    private readonly CommandRegistry _commandRegistry;
    private readonly AgentCommandParser _agentCommandParser;
    private readonly AgentCommandExecutor _agentCommandExecutor;
    private readonly DeepSeekClient _deepSeekClient;
    private readonly ChatSettings _chatSettings;

    private ChatSession _chatSession = null!;
    private long? _lastMessageId = null;

    public AgentChat(
        LocalCommandContext localCommandContext,
        CommandRegistry commandRegistry,
        AgentCommandParser agentCommandParser,
        AgentCommandExecutor agentCommandExecutor,
        DeepSeekClient deepSeekClient,
        ChatSettings chatSettings)
    {
        InitializeComponent();
        _localCommandContext = localCommandContext;
        _commandRegistry = commandRegistry;
        _agentCommandParser = agentCommandParser;
        _agentCommandExecutor = agentCommandExecutor;
        _deepSeekClient = deepSeekClient;
        _chatSettings = chatSettings;

        Dock = DockStyle.Fill;

        Task.Run(async () =>
        {
            await CreateChatSession();
        });
    }

    public LocalCommandContext LocalCommandContext => _localCommandContext;
    public ChatSettings ChatSettings => _chatSettings;

    public async Task ClearHistory()
    {
        await CreateChatSession();
    }

    private async Task CreateChatSession()
    {
        try
        {
            _chatSession = await _deepSeekClient.CreateChatSessionAsync();
            _lastMessageId = null;

            var basePromt = ResourcesDataLoader.GetDataText("BOOTSTRAP.md");
            var promt = basePromt + "\n\n" + "Процесс инициализации";

            await StartHandle(promt);
        }
        catch { }
    }

    private async void richTextBoxPromt_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && e.Shift == false)
        {
            var task = richTextBoxPromt.Text;
            richTextBoxPromt.Clear();
            
            var promt = task;

            richTextBoxPromt.ReadOnly = true;

            await Task.Run(async () =>
            {
                if (_lastMessageId != null)
                {
                    richTextBoxLogs.LogLine();
                    richTextBoxLogs.LogLine();
                }

                richTextBoxLogs.LogLine("[TASK]:", TASK_COLOR);
                richTextBoxLogs.LogLine(task.TrimEnd());
                richTextBoxLogs.LogLine();

                await StartHandle(promt);
            });

            richTextBoxPromt.ReadOnly = false;
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

                if (commands.Count > 0)
                {
                    var resultsForAi = await _agentCommandExecutor.ExecuteCommandsAsync(commands);

                    richTextBoxLogs.LogLine("");
                    richTextBoxLogs.LogLine("");
                    richTextBoxLogs.LogLine("[COMMANDS]:", COMMANDS_COLOR);
                    richTextBoxLogs.LogLine(resultsForAi.response);

                    if (resultsForAi.end)
                    {
                        break;
                    }

                    while (true)
                    {
                        try
                        {
                            response = await SendMessage(
                                _chatSession,
                                resultsForAi.response,
                                _chatSettings,
                                _lastMessageId);
                            break;
                        }
                        catch (RateLimitError)
                        {
                            richTextBoxLogs.LogLine("Rate limit exeption.", API_ERROR_COLOR);
                            richTextBoxLogs.Log("Wait to send message again", API_ERROR_COLOR);

                            for (var i = 0; i < 3; i++)
                            {
                                await Task.Delay(2500);
                                richTextBoxLogs.Log(".", API_ERROR_COLOR);
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
        richTextBoxLogs.LogLine("[DEEPSEEK]:", DEEPSEEK_COLOR);

        long? messageId = null;
        var text = string.Empty;

        await foreach (var token in _deepSeekClient.SendMessageStream(
            chatSession,
            prompt,
            chatSettings,
            parentMessage))
        {
            messageId = token.MessageId;
            text += token.Text;
            richTextBoxLogs.Log(token.Text);
        }

        return (messageId, text);
    }
}

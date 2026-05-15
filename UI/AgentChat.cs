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

    private ChatSession? _chatSession = null;
    private long? _lastMessageId = null;
    private bool _userStop = false;

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
    }

    public LocalCommandContext LocalCommandContext => _localCommandContext;
    public ChatSettings ChatSettings => _chatSettings;

    private async void buttonDeepSeekSession_Click(object sender, EventArgs e)
    {
        if (_chatSession == null)
        {
            buttonDeepSeekSession.Enabled = false;
            await CreateChatSession();

            _userStop = false;
            buttonDeepSeekSession.Enabled = true;
            buttonDeepSeekSession.Text = "Очистить историю";
            buttonDeepSeekStopGeneration.Enabled = true;
        }
        else
        {
            _chatSession = null;
            _lastMessageId = null;
            _userStop = true;

            buttonDeepSeekSession.Enabled = true;
            buttonDeepSeekSession.Text = "Инициализировать";
            buttonDeepSeekStopGeneration.Enabled = false;
            richTextBoxLogs.Clear();
        }
    }

    private async void buttonDeepSeekStopGeneration_Click(object sender, EventArgs e)
    {
        if (_chatSession == null || _lastMessageId == null)
        {
            return;
        }

        _userStop = true;
        await _deepSeekClient.StopGenerationAsync(_chatSession, _lastMessageId.Value);
        richTextBoxLogs.LogLine("\nSTOP GENERATION", Color.Red);
    }

    private async void richTextBoxPromt_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && e.Shift == false)
        {
            if (_chatSession == null)
            {
                return;
            }

            var task = richTextBoxPromt.Text;
            richTextBoxPromt.Clear();
            richTextBoxPromt.ReadOnly = true;

            _userStop = false;
            await Task.Run(async () =>
            {
                if (_lastMessageId != null)
                {
                    richTextBoxLogs.LogLine();
                    richTextBoxLogs.LogLine();
                }

                richTextBoxLogs.LogLine("[USER]:", TASK_COLOR);
                richTextBoxLogs.LogLine(task.TrimEnd());
                richTextBoxLogs.LogLine();

                await StartHandle(task);
            });

            richTextBoxPromt.ReadOnly = false;
        }
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

    private async Task StartHandle(string promt)
    {
        try
        {
            var response = await SendWithRetryAsync(promt);

            while (true)
            {
                if (_userStop)
                {
                    break;
                }

                var commands = _agentCommandParser.Parse(response);

                var resultsForAi = await _agentCommandExecutor.ExecuteCommandsAsync(commands);

                if (resultsForAi.end)
                {
                    break;
                }

                richTextBoxLogs.LogLine("");
                richTextBoxLogs.LogLine("");
                richTextBoxLogs.LogLine("[COMMANDS]:", COMMANDS_COLOR);
                richTextBoxLogs.LogLine(resultsForAi.response);

                if (commands.Count == 0)
                {
                    resultsForAi.response = """
                    Твой ответ не содержит команд или завершениея цикла. 
                    (`COMMAND MESSAGE` - отправить сообщение человеку,
                    `COMMAND FINALLY` - завершить цикл агента)
                    """;
                    richTextBoxLogs.LogLine("[Error]: ИИ выдал ответ без команд и не завершил задачу.", Color.Red);
                }

                response = await SendWithRetryAsync(resultsForAi.response);
            }

        }
        catch (Exception ex)
        {
            richTextBoxLogs.LogLine(ex.ToString(), Color.Red);
        }
    }

    private async Task<string> SendWithRetryAsync(string prompt)
    {
        var response = string.Empty;

        while (true)
        {
            try
            {
                response = await SendMessage(
                    _chatSession!,
                    prompt,
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

        return response;
    }

    private async Task<string> SendMessage(
        ChatSession chatSession,
        string prompt,
        ChatSettings chatSettings,
        long? parentMessage = null)
    {
        richTextBoxLogs.LogLine("[DEEPSEEK]:", DEEPSEEK_COLOR);

        var text = string.Empty;

        await foreach (var token in _deepSeekClient.SendMessageStream(
            chatSession,
            prompt,
            chatSettings,
            parentMessage))
        {
            _lastMessageId = token.MessageId;
            text += token.Text;
            richTextBoxLogs.Log(token.Text);
        }

        return text;
    }
}

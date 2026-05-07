using DeepSeekAgent.Commands;
using DeepSeekAgent.ConPTY;
using System;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormPseudoConsole : Form
{
    private readonly PseudoConsoleProcess _pseudoConsoleProcess;

    public FormPseudoConsole(PseudoConsoleProcess pseudoConsoleProcess)
    {
        InitializeComponent();
        _pseudoConsoleProcess = pseudoConsoleProcess;
        _pseudoConsoleProcess.Output += Console_Output;
    }

    private void Console_Output(string obj)
    {
        if (richTextBoxLogs.InvokeRequired)
        {
            richTextBoxLogs.Invoke(new Action(() =>
            {
                AppendAndScroll(obj);
            }));
        }
        else
        {
            AppendAndScroll(obj);
        }
    }

    private void AppendAndScroll(string obj)
    {
        richTextBoxLogs.AppendText(obj);

        richTextBoxLogs.SelectionStart = richTextBoxLogs.TextLength;
        richTextBoxLogs.SelectionLength = 0;

        richTextBoxLogs.ScrollToCaret();
    }

    private async void textBoxCommandInput_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;

            var cmd = textBoxCommandInput.Text;

            textBoxCommandInput.Clear();

            await _pseudoConsoleProcess.WriteAsync(cmd);
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _pseudoConsoleProcess.Output -= Console_Output;
        base.OnFormClosed(e);
    }
}
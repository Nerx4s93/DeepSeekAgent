using DeepSeekAgent.Commands;
using System;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormWSL : Form
{
    private readonly LocalCommandContext _localCommandContext;

    public FormWSL(LocalCommandContext localCommandContext)
    {
        InitializeComponent();
        _localCommandContext = localCommandContext;
        localCommandContext.WSL.Output += Wsl_Output;
    }

    private void Wsl_Output(string obj)
    {
        if (richTextBoxLogsWSL.InvokeRequired)
        {
            richTextBoxLogsWSL.Invoke(new Action(() =>
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
        richTextBoxLogsWSL.AppendText(obj);

        richTextBoxLogsWSL.SelectionStart = richTextBoxLogsWSL.TextLength;
        richTextBoxLogsWSL.SelectionLength = 0;

        richTextBoxLogsWSL.ScrollToCaret();
    }

    private async void textBoxCommandInput_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            var cmd = textBoxCommandInput.Text;
            textBoxCommandInput.Clear();

            await _localCommandContext.WSL.WriteAsync(cmd);
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _localCommandContext.WSL.Output -= Wsl_Output;
        base.OnFormClosed(e);
    }
}
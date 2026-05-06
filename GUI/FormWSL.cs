using System;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormWSL : Form
{
    public FormWSL()
    {
        InitializeComponent();

        WslManager.Output += Wsl_Output;
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

            await WslManager.WriteAsync(cmd);
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        WslManager.Output -= Wsl_Output;
        base.OnFormClosed(e);
    }
}
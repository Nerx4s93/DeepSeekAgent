using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormWSL : Form
{
    public FormWSL()
    {
        InitializeComponent();
        WslManager.OnOutput += WslManager_OnOutput;
        WslManager.OnError += WslManager_OnError;
    }

    private void WslManager_OnOutput(string obj)
    {
        richTextBoxLogsWSL.Text += obj + "\n\n";
    }

    private void WslManager_OnError(string obj)
    {
        richTextBoxLogsWSL.Text += obj + "\n\n";
    }

    private async void textBoxCommandInput_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            await WslManager.SendCommandAsync(textBoxCommandInput.Text);
            textBoxCommandInput.Clear();
        }
    }
}

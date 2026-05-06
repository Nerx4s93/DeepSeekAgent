using System;
using System.Windows.Forms;

namespace DeepSeekAgent.GUI;

public partial class FormStartPromt : Form
{
    public FormStartPromt()
    {
        InitializeComponent();
    }

    public string Result = string.Empty;

    private void buttonStart_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Result = richTextBoxPromt.Text;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

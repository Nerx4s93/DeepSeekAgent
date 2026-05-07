namespace DeepSeekAgent.GUI;

partial class FormWSL
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        richTextBoxLogsWSL = new System.Windows.Forms.RichTextBox();
        textBoxCommandInput = new System.Windows.Forms.TextBox();
        panel1 = new System.Windows.Forms.Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // richTextBoxLogsWSL
        // 
        richTextBoxLogsWSL.BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        richTextBoxLogsWSL.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBoxLogsWSL.ForeColor = System.Drawing.Color.Gainsboro;
        richTextBoxLogsWSL.Location = new System.Drawing.Point(0, 0);
        richTextBoxLogsWSL.Name = "richTextBoxLogsWSL";
        richTextBoxLogsWSL.ReadOnly = true;
        richTextBoxLogsWSL.Size = new System.Drawing.Size(918, 479);
        richTextBoxLogsWSL.TabIndex = 0;
        richTextBoxLogsWSL.Text = "";
        // 
        // textBoxCommandInput
        // 
        textBoxCommandInput.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        textBoxCommandInput.Dock = System.Windows.Forms.DockStyle.Bottom;
        textBoxCommandInput.ForeColor = System.Drawing.Color.Gainsboro;
        textBoxCommandInput.Location = new System.Drawing.Point(0, 479);
        textBoxCommandInput.Name = "textBoxCommandInput";
        textBoxCommandInput.Size = new System.Drawing.Size(918, 31);
        textBoxCommandInput.TabIndex = 1;
        textBoxCommandInput.KeyDown += textBoxCommandInput_KeyDown;
        // 
        // panel1
        // 
        panel1.Controls.Add(richTextBoxLogsWSL);
        panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(918, 479);
        panel1.TabIndex = 2;
        // 
        // FormWSL
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        ClientSize = new System.Drawing.Size(918, 510);
        Controls.Add(panel1);
        Controls.Add(textBoxCommandInput);
        Font = new System.Drawing.Font("Cascadia Mono", 10F);
        ForeColor = System.Drawing.Color.Gainsboro;
        Name = "FormWSL";
        Text = "FormWSL";
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBoxLogsWSL;
    private System.Windows.Forms.TextBox textBoxCommandInput;
    private System.Windows.Forms.Panel panel1;
}
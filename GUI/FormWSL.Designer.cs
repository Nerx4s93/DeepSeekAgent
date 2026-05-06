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
        SuspendLayout();
        // 
        // richTextBoxLogsWSL
        // 
        richTextBoxLogsWSL.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBoxLogsWSL.Location = new System.Drawing.Point(0, 0);
        richTextBoxLogsWSL.Margin = new System.Windows.Forms.Padding(4);
        richTextBoxLogsWSL.Name = "richTextBoxLogsWSL";
        richTextBoxLogsWSL.ReadOnly = true;
        richTextBoxLogsWSL.Size = new System.Drawing.Size(1247, 616);
        richTextBoxLogsWSL.TabIndex = 0;
        richTextBoxLogsWSL.Text = "";
        // 
        // textBoxCommandInput
        // 
        textBoxCommandInput.Dock = System.Windows.Forms.DockStyle.Bottom;
        textBoxCommandInput.Location = new System.Drawing.Point(0, 577);
        textBoxCommandInput.Margin = new System.Windows.Forms.Padding(4);
        textBoxCommandInput.Name = "textBoxCommandInput";
        textBoxCommandInput.Size = new System.Drawing.Size(1247, 39);
        textBoxCommandInput.TabIndex = 1;
        textBoxCommandInput.KeyDown += textBoxCommandInput_KeyDown;
        // 
        // FormWSL
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1247, 616);
        Controls.Add(textBoxCommandInput);
        Controls.Add(richTextBoxLogsWSL);
        Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        Margin = new System.Windows.Forms.Padding(4);
        Name = "FormWSL";
        Text = "FormWSL";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBoxLogsWSL;
    private System.Windows.Forms.TextBox textBoxCommandInput;
}
namespace DeepSeekAgent.UI;

partial class AgentChat
{
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        richTextBoxLogs = new LogsRichTextBox();
        richTextBoxPromt = new FastRichTextBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Margin = new System.Windows.Forms.Padding(4);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        splitContainer1.Panel1.Controls.Add(richTextBoxLogs);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(richTextBoxPromt);
        splitContainer1.Size = new System.Drawing.Size(1097, 640);
        splitContainer1.SplitterDistance = 469;
        splitContainer1.SplitterWidth = 5;
        splitContainer1.TabIndex = 12;
        // 
        // richTextBoxLogs
        // 
        richTextBoxLogs.BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        richTextBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBoxLogs.ForeColor = System.Drawing.Color.Gainsboro;
        richTextBoxLogs.Location = new System.Drawing.Point(0, 0);
        richTextBoxLogs.Name = "richTextBoxLogs";
        richTextBoxLogs.Size = new System.Drawing.Size(1097, 469);
        richTextBoxLogs.TabIndex = 1;
        richTextBoxLogs.Text = "";
        // 
        // richTextBoxPromt
        // 
        richTextBoxPromt.BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        richTextBoxPromt.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBoxPromt.ForeColor = System.Drawing.Color.Gainsboro;
        richTextBoxPromt.Location = new System.Drawing.Point(0, 0);
        richTextBoxPromt.Name = "richTextBoxPromt";
        richTextBoxPromt.Size = new System.Drawing.Size(1097, 166);
        richTextBoxPromt.TabIndex = 1;
        richTextBoxPromt.Text = "";
        richTextBoxPromt.KeyDown += richTextBoxPromt_KeyDown;
        // 
        // AgentChat
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        Controls.Add(splitContainer1);
        Font = new System.Drawing.Font("Cascadia Mono", 12F);
        ForeColor = System.Drawing.Color.Gainsboro;
        Margin = new System.Windows.Forms.Padding(4);
        Name = "AgentChat";
        Size = new System.Drawing.Size(1097, 640);
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private LogsRichTextBox richTextBoxLogs;
    private FastRichTextBox richTextBoxPromt;
}

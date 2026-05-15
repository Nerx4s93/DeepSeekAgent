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
        panel2 = new System.Windows.Forms.Panel();
        richTextBoxPromt = new FastRichTextBox();
        panel1 = new System.Windows.Forms.Panel();
        buttonDeepSeekStopGeneration = new System.Windows.Forms.Button();
        buttonDeepSeekSession = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        panel2.SuspendLayout();
        panel1.SuspendLayout();
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
        splitContainer1.Panel2.Controls.Add(panel2);
        splitContainer1.Panel2.Controls.Add(panel1);
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
        richTextBoxLogs.ReadOnly = true;
        richTextBoxLogs.Size = new System.Drawing.Size(1097, 469);
        richTextBoxLogs.TabIndex = 1;
        richTextBoxLogs.Text = "";
        // 
        // panel2
        // 
        panel2.Controls.Add(richTextBoxPromt);
        panel2.Dock = System.Windows.Forms.DockStyle.Fill;
        panel2.Location = new System.Drawing.Point(300, 0);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(797, 166);
        panel2.TabIndex = 3;
        // 
        // richTextBoxPromt
        // 
        richTextBoxPromt.BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        richTextBoxPromt.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBoxPromt.ForeColor = System.Drawing.Color.Gainsboro;
        richTextBoxPromt.Location = new System.Drawing.Point(0, 0);
        richTextBoxPromt.Name = "richTextBoxPromt";
        richTextBoxPromt.Size = new System.Drawing.Size(797, 166);
        richTextBoxPromt.TabIndex = 1;
        richTextBoxPromt.Text = "";
        richTextBoxPromt.KeyDown += richTextBoxPromt_KeyDown;
        // 
        // panel1
        // 
        panel1.Controls.Add(buttonDeepSeekStopGeneration);
        panel1.Controls.Add(buttonDeepSeekSession);
        panel1.Dock = System.Windows.Forms.DockStyle.Left;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(300, 166);
        panel1.TabIndex = 2;
        // 
        // buttonDeepSeekStopGeneration
        // 
        buttonDeepSeekStopGeneration.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        buttonDeepSeekStopGeneration.Enabled = false;
        buttonDeepSeekStopGeneration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        buttonDeepSeekStopGeneration.Location = new System.Drawing.Point(3, 62);
        buttonDeepSeekStopGeneration.Name = "buttonDeepSeekStopGeneration";
        buttonDeepSeekStopGeneration.Size = new System.Drawing.Size(291, 53);
        buttonDeepSeekStopGeneration.TabIndex = 1;
        buttonDeepSeekStopGeneration.Text = "Остановить";
        buttonDeepSeekStopGeneration.UseVisualStyleBackColor = false;
        buttonDeepSeekStopGeneration.Click += buttonDeepSeekStopGeneration_Click;
        // 
        // buttonDeepSeekSession
        // 
        buttonDeepSeekSession.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        buttonDeepSeekSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        buttonDeepSeekSession.Location = new System.Drawing.Point(3, 3);
        buttonDeepSeekSession.Name = "buttonDeepSeekSession";
        buttonDeepSeekSession.Size = new System.Drawing.Size(291, 53);
        buttonDeepSeekSession.TabIndex = 0;
        buttonDeepSeekSession.Text = "Инициализировать";
        buttonDeepSeekSession.UseVisualStyleBackColor = false;
        buttonDeepSeekSession.Click += buttonDeepSeekSession_Click;
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
        panel2.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private LogsRichTextBox richTextBoxLogs;
    private FastRichTextBox richTextBoxPromt;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button buttonDeepSeekSession;
    private System.Windows.Forms.Button buttonDeepSeekStopGeneration;
}

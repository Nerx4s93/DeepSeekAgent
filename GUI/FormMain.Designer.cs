using System.Drawing;

namespace DeepSeekAgent.GUI;

partial class FormMain
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
        buttonStart = new System.Windows.Forms.Button();
        buttonChangeApiKey = new System.Windows.Forms.Button();
        buttonClearHistory = new System.Windows.Forms.Button();
        buttonWSL = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // buttonStart
        // 
        buttonStart.Enabled = false;
        buttonStart.Location = new Point(9, 12);
        buttonStart.Name = "buttonStart";
        buttonStart.Size = new Size(384, 50);
        buttonStart.TabIndex = 4;
        buttonStart.Text = "Запуск";
        buttonStart.UseVisualStyleBackColor = true;
        buttonStart.Click += buttonStart_Click;
        // 
        // buttonChangeApiKey
        // 
        buttonChangeApiKey.Location = new Point(705, 12);
        buttonChangeApiKey.Name = "buttonChangeApiKey";
        buttonChangeApiKey.Size = new Size(300, 50);
        buttonChangeApiKey.TabIndex = 5;
        buttonChangeApiKey.Text = "Изменить api ключ";
        buttonChangeApiKey.UseVisualStyleBackColor = true;
        buttonChangeApiKey.Click += buttonChangeApiKey_Click;
        // 
        // buttonClearHistory
        // 
        buttonClearHistory.Location = new Point(705, 68);
        buttonClearHistory.Name = "buttonClearHistory";
        buttonClearHistory.Size = new Size(300, 50);
        buttonClearHistory.TabIndex = 6;
        buttonClearHistory.Text = "Очистить историю";
        buttonClearHistory.UseVisualStyleBackColor = true;
        buttonClearHistory.Click += buttonClearHistory_Click;
        // 
        // buttonWSL
        // 
        buttonWSL.Location = new Point(399, 12);
        buttonWSL.Name = "buttonWSL";
        buttonWSL.Size = new Size(300, 50);
        buttonWSL.TabIndex = 7;
        buttonWSL.Text = "WSL";
        buttonWSL.UseVisualStyleBackColor = true;
        buttonWSL.Click += buttonWSL_Click;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(15F, 38F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1020, 129);
        Controls.Add(buttonWSL);
        Controls.Add(buttonClearHistory);
        Controls.Add(buttonChangeApiKey);
        Controls.Add(buttonStart);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        Name = "FormMain";
        Text = "FormMain";
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.Button buttonChangeApiKey;
    private System.Windows.Forms.Button buttonClearHistory;
    private System.Windows.Forms.Button buttonWSL;
}
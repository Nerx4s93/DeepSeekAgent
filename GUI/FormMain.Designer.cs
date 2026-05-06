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
        menuStrip = new System.Windows.Forms.MenuStrip();
        файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonClearHistory = new System.Windows.Forms.ToolStripMenuItem();
        настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonChangeApiKey = new System.Windows.Forms.ToolStripMenuItem();
        инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonWSL = new System.Windows.Forms.ToolStripMenuItem();
        menuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // buttonStart
        // 
        buttonStart.Enabled = false;
        buttonStart.Location = new Point(453, 209);
        buttonStart.Name = "buttonStart";
        buttonStart.Size = new Size(260, 42);
        buttonStart.TabIndex = 4;
        buttonStart.Text = "Запуск";
        buttonStart.UseVisualStyleBackColor = true;
        buttonStart.Click += buttonStart_Click;
        // 
        // menuStrip
        // 
        menuStrip.BackColor = Color.FromArgb(30, 30, 30);
        menuStrip.Font = new Font("Segoe UI", 12F);
        menuStrip.ImageScalingSize = new Size(24, 24);
        menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { файлToolStripMenuItem, настройкиToolStripMenuItem, инструментыToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
        menuStrip.Size = new Size(1134, 40);
        menuStrip.TabIndex = 8;
        menuStrip.Text = "menuStrip1";
        // 
        // файлToolStripMenuItem
        // 
        файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonClearHistory });
        файлToolStripMenuItem.ForeColor = Color.Silver;
        файлToolStripMenuItem.Name = "файлToolStripMenuItem";
        файлToolStripMenuItem.Size = new Size(86, 36);
        файлToolStripMenuItem.Text = "Файл";
        // 
        // buttonClearHistory
        // 
        buttonClearHistory.BackColor = Color.FromArgb(30, 30, 30);
        buttonClearHistory.ForeColor = Color.Silver;
        buttonClearHistory.Name = "buttonClearHistory";
        buttonClearHistory.Size = new Size(325, 40);
        buttonClearHistory.Text = "Очистить историю";
        buttonClearHistory.Click += buttonClearHistory_Click;
        // 
        // настройкиToolStripMenuItem
        // 
        настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonChangeApiKey });
        настройкиToolStripMenuItem.ForeColor = Color.Silver;
        настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
        настройкиToolStripMenuItem.Size = new Size(148, 36);
        настройкиToolStripMenuItem.Text = "Настройки";
        // 
        // buttonChangeApiKey
        // 
        buttonChangeApiKey.BackColor = Color.FromArgb(30, 30, 30);
        buttonChangeApiKey.ForeColor = Color.Silver;
        buttonChangeApiKey.Name = "buttonChangeApiKey";
        buttonChangeApiKey.Size = new Size(332, 40);
        buttonChangeApiKey.Text = "Изменить api ключ";
        buttonChangeApiKey.Click += buttonChangeApiKey_Click;
        // 
        // инструментыToolStripMenuItem
        // 
        инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonWSL });
        инструментыToolStripMenuItem.ForeColor = Color.Silver;
        инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
        инструментыToolStripMenuItem.Size = new Size(180, 36);
        инструментыToolStripMenuItem.Text = "Инструменты";
        // 
        // buttonWSL
        // 
        buttonWSL.BackColor = Color.FromArgb(30, 30, 30);
        buttonWSL.ForeColor = Color.Silver;
        buttonWSL.Name = "buttonWSL";
        buttonWSL.Size = new Size(270, 40);
        buttonWSL.Text = "WSL";
        buttonWSL.Click += buttonWSL_Click;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(1134, 565);
        Controls.Add(buttonStart);
        Controls.Add(menuStrip);
        Font = new Font("Segoe UI", 12F);
        ForeColor = Color.Gray;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MainMenuStrip = menuStrip;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        Name = "FormMain";
        Text = "FormMain";
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonClearHistory;
    private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonChangeApiKey;
    private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonWSL;
}
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
        menuStrip = new System.Windows.Forms.MenuStrip();
        файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonClearHistory = new System.Windows.Forms.ToolStripMenuItem();
        настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonChangeApiKey = new System.Windows.Forms.ToolStripMenuItem();
        инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonShowWSL = new System.Windows.Forms.ToolStripMenuItem();
        buttonShowPowerShell = new System.Windows.Forms.ToolStripMenuItem();
        agentManager = new DeepSeekAgent.UI.AgentManager();
        menuStrip.SuspendLayout();
        SuspendLayout();
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
        menuStrip.Size = new Size(1221, 40);
        menuStrip.TabIndex = 8;
        menuStrip.Text = "menuStrip1";
        // 
        // файлToolStripMenuItem
        // 
        файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonClearHistory });
        файлToolStripMenuItem.ForeColor = Color.Gainsboro;
        файлToolStripMenuItem.Name = "файлToolStripMenuItem";
        файлToolStripMenuItem.Size = new Size(86, 36);
        файлToolStripMenuItem.Text = "Файл";
        // 
        // buttonClearHistory
        // 
        buttonClearHistory.BackColor = Color.FromArgb(30, 30, 30);
        buttonClearHistory.ForeColor = Color.Gainsboro;
        buttonClearHistory.Name = "buttonClearHistory";
        buttonClearHistory.Size = new Size(325, 40);
        buttonClearHistory.Text = "Очистить историю";
        buttonClearHistory.Click += buttonClearHistory_Click;
        // 
        // настройкиToolStripMenuItem
        // 
        настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonChangeApiKey });
        настройкиToolStripMenuItem.ForeColor = Color.Gainsboro;
        настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
        настройкиToolStripMenuItem.Size = new Size(148, 36);
        настройкиToolStripMenuItem.Text = "Настройки";
        // 
        // buttonChangeApiKey
        // 
        buttonChangeApiKey.BackColor = Color.FromArgb(30, 30, 30);
        buttonChangeApiKey.ForeColor = Color.Gainsboro;
        buttonChangeApiKey.Name = "buttonChangeApiKey";
        buttonChangeApiKey.Size = new Size(332, 40);
        buttonChangeApiKey.Text = "Изменить api ключ";
        buttonChangeApiKey.Click += buttonChangeApiKey_Click;
        // 
        // инструментыToolStripMenuItem
        // 
        инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonShowWSL, buttonShowPowerShell });
        инструментыToolStripMenuItem.ForeColor = Color.Gainsboro;
        инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
        инструментыToolStripMenuItem.Size = new Size(180, 36);
        инструментыToolStripMenuItem.Text = "Инструменты";
        // 
        // buttonShowWSL
        // 
        buttonShowWSL.BackColor = Color.FromArgb(30, 30, 30);
        buttonShowWSL.ForeColor = Color.Gainsboro;
        buttonShowWSL.Name = "buttonShowWSL";
        buttonShowWSL.Size = new Size(234, 40);
        buttonShowWSL.Text = "WSL";
        buttonShowWSL.Click += buttonShowWSL_Click;
        // 
        // buttonShowPowerShell
        // 
        buttonShowPowerShell.BackColor = Color.FromArgb(30, 30, 30);
        buttonShowPowerShell.ForeColor = Color.Gainsboro;
        buttonShowPowerShell.Name = "buttonShowPowerShell";
        buttonShowPowerShell.Size = new Size(234, 40);
        buttonShowPowerShell.Text = "PowerShell";
        buttonShowPowerShell.Click += buttonShowPowerShell_Click;
        // 
        // agentManager
        // 
        agentManager.BackColor = Color.FromArgb(12, 12, 12);
        agentManager.Dock = System.Windows.Forms.DockStyle.Fill;
        agentManager.Font = new Font("Cascadia Mono", 12F);
        agentManager.ForeColor = Color.Gainsboro;
        agentManager.Location = new Point(0, 40);
        agentManager.Margin = new System.Windows.Forms.Padding(4);
        agentManager.Name = "agentManager";
        agentManager.Size = new Size(1221, 525);
        agentManager.TabIndex = 10;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(14F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = Color.FromArgb(12, 12, 12);
        ClientSize = new Size(1221, 565);
        Controls.Add(agentManager);
        Controls.Add(menuStrip);
        Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        ForeColor = Color.Gainsboro;
        MainMenuStrip = menuStrip;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        Name = "FormMain";
        Text = "FormMain";
        Shown += FormMain_Shown;
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonClearHistory;
    private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonChangeApiKey;
    private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonShowWSL;
    private System.Windows.Forms.ToolStripMenuItem buttonShowPowerShell;
    private UI.AgentManager agentManager;
}
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
        настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        чатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        buttonDeepSeekToggleThinking = new System.Windows.Forms.ToolStripMenuItem();
        buttonDeepSeekToggleSearch = new System.Windows.Forms.ToolStripMenuItem();
        buttonDeepSeekToggleSwichMode = new System.Windows.Forms.ToolStripMenuItem();
        buttonModelDefault = new System.Windows.Forms.ToolStripMenuItem();
        buttonModelExpert = new System.Windows.Forms.ToolStripMenuItem();
        buttonModelVision = new System.Windows.Forms.ToolStripMenuItem();
        buttonAddAgent = new System.Windows.Forms.ToolStripMenuItem();
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
        menuStrip.Font = new Font("Cascadia Mono", 12F);
        menuStrip.ImageScalingSize = new Size(24, 24);
        menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { настройкиToolStripMenuItem, инструментыToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
        menuStrip.Size = new Size(1221, 40);
        menuStrip.TabIndex = 8;
        menuStrip.Text = "menuStrip1";
        // 
        // настройкиToolStripMenuItem
        // 
        настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { чатToolStripMenuItem, buttonAddAgent });
        настройкиToolStripMenuItem.ForeColor = Color.Gainsboro;
        настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
        настройкиToolStripMenuItem.Size = new Size(156, 36);
        настройкиToolStripMenuItem.Text = "Настройки";
        // 
        // чатToolStripMenuItem
        // 
        чатToolStripMenuItem.BackColor = Color.FromArgb(30, 30, 30);
        чатToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonDeepSeekToggleThinking, buttonDeepSeekToggleSearch, buttonDeepSeekToggleSwichMode });
        чатToolStripMenuItem.ForeColor = Color.Gainsboro;
        чатToolStripMenuItem.Name = "чатToolStripMenuItem";
        чатToolStripMenuItem.Size = new Size(328, 40);
        чатToolStripMenuItem.Text = "Чат";
        // 
        // buttonDeepSeekToggleThinking
        // 
        buttonDeepSeekToggleThinking.BackColor = Color.FromArgb(30, 30, 30);
        buttonDeepSeekToggleThinking.ForeColor = Color.Gainsboro;
        buttonDeepSeekToggleThinking.Name = "buttonDeepSeekToggleThinking";
        buttonDeepSeekToggleThinking.Size = new Size(356, 40);
        buttonDeepSeekToggleThinking.Text = "Thinking: Disable";
        buttonDeepSeekToggleThinking.Click += buttonDeepSeekToggleThinking_Click;
        // 
        // buttonDeepSeekToggleSearch
        // 
        buttonDeepSeekToggleSearch.BackColor = Color.FromArgb(30, 30, 30);
        buttonDeepSeekToggleSearch.ForeColor = Color.Gainsboro;
        buttonDeepSeekToggleSearch.Name = "buttonDeepSeekToggleSearch";
        buttonDeepSeekToggleSearch.Size = new Size(356, 40);
        buttonDeepSeekToggleSearch.Text = "Search: Disable";
        buttonDeepSeekToggleSearch.Click += buttonDeepSeekToggleSearch_Click;
        // 
        // buttonDeepSeekToggleSwichMode
        // 
        buttonDeepSeekToggleSwichMode.BackColor = Color.FromArgb(30, 30, 30);
        buttonDeepSeekToggleSwichMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonModelDefault, buttonModelExpert, buttonModelVision });
        buttonDeepSeekToggleSwichMode.ForeColor = Color.Gainsboro;
        buttonDeepSeekToggleSwichMode.Name = "buttonDeepSeekToggleSwichMode";
        buttonDeepSeekToggleSwichMode.Size = new Size(356, 40);
        buttonDeepSeekToggleSwichMode.Text = "Model: Expert";
        // 
        // buttonModelDefault
        // 
        buttonModelDefault.BackColor = Color.FromArgb(30, 30, 30);
        buttonModelDefault.ForeColor = Color.Gainsboro;
        buttonModelDefault.Name = "buttonModelDefault";
        buttonModelDefault.Size = new Size(216, 40);
        buttonModelDefault.Text = "Default";
        buttonModelDefault.Click += buttonModelDefault_Click;
        // 
        // buttonModelExpert
        // 
        buttonModelExpert.BackColor = Color.FromArgb(30, 30, 30);
        buttonModelExpert.ForeColor = Color.Gainsboro;
        buttonModelExpert.Name = "buttonModelExpert";
        buttonModelExpert.Size = new Size(216, 40);
        buttonModelExpert.Text = "Expert";
        buttonModelExpert.Click += buttonModelExpert_Click;
        // 
        // buttonModelVision
        // 
        buttonModelVision.BackColor = Color.FromArgb(30, 30, 30);
        buttonModelVision.ForeColor = Color.Gainsboro;
        buttonModelVision.Name = "buttonModelVision";
        buttonModelVision.Size = new Size(216, 40);
        buttonModelVision.Text = "Vision";
        buttonModelVision.Click += buttonModelVision_Click;
        // 
        // buttonAddAgent
        // 
        buttonAddAgent.BackColor = Color.FromArgb(30, 30, 30);
        buttonAddAgent.ForeColor = Color.Gainsboro;
        buttonAddAgent.Name = "buttonAddAgent";
        buttonAddAgent.Size = new Size(328, 40);
        buttonAddAgent.Text = "Добавить агента";
        buttonAddAgent.Click += buttonAddAgent_Click;
        // 
        // инструментыToolStripMenuItem
        // 
        инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonShowWSL, buttonShowPowerShell });
        инструментыToolStripMenuItem.ForeColor = Color.Gainsboro;
        инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
        инструментыToolStripMenuItem.Size = new Size(184, 36);
        инструментыToolStripMenuItem.Text = "Инструменты";
        // 
        // buttonShowWSL
        // 
        buttonShowWSL.BackColor = Color.FromArgb(30, 30, 30);
        buttonShowWSL.ForeColor = Color.Gainsboro;
        buttonShowWSL.Name = "buttonShowWSL";
        buttonShowWSL.Size = new Size(258, 40);
        buttonShowWSL.Text = "WSL";
        buttonShowWSL.Click += buttonShowWSL_Click;
        // 
        // buttonShowPowerShell
        // 
        buttonShowPowerShell.BackColor = Color.FromArgb(30, 30, 30);
        buttonShowPowerShell.ForeColor = Color.Gainsboro;
        buttonShowPowerShell.Name = "buttonShowPowerShell";
        buttonShowPowerShell.Size = new Size(258, 40);
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
        agentManager.SelectedTabChanged += agentManager_SelectedTabChanged;
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
    private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonShowWSL;
    private System.Windows.Forms.ToolStripMenuItem buttonShowPowerShell;
    private UI.AgentManager agentManager;
    private System.Windows.Forms.ToolStripMenuItem чатToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buttonDeepSeekToggleThinking;
    private System.Windows.Forms.ToolStripMenuItem buttonDeepSeekToggleSearch;
    private System.Windows.Forms.ToolStripMenuItem buttonDeepSeekToggleSwichMode;
    private System.Windows.Forms.ToolStripMenuItem buttonAddAgent;
    private System.Windows.Forms.ToolStripMenuItem buttonModelDefault;
    private System.Windows.Forms.ToolStripMenuItem buttonModelExpert;
    private System.Windows.Forms.ToolStripMenuItem buttonModelVision;
}
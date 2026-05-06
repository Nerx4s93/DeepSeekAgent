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
        buttonWSL = new System.Windows.Forms.ToolStripMenuItem();
        richTextBoxPromt = new System.Windows.Forms.RichTextBox();
        richTextBox2 = new System.Windows.Forms.RichTextBox();
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        menuStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
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
        menuStrip.Size = new Size(1134, 40);
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
        инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { buttonWSL });
        инструментыToolStripMenuItem.ForeColor = Color.Gainsboro;
        инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
        инструментыToolStripMenuItem.Size = new Size(180, 36);
        инструментыToolStripMenuItem.Text = "Инструменты";
        // 
        // buttonWSL
        // 
        buttonWSL.BackColor = Color.FromArgb(30, 30, 30);
        buttonWSL.ForeColor = Color.Gainsboro;
        buttonWSL.Name = "buttonWSL";
        buttonWSL.Size = new Size(164, 40);
        buttonWSL.Text = "WSL";
        buttonWSL.Click += buttonWSL_Click;
        // 
        // richTextBoxPromt
        // 
        richTextBoxPromt.BackColor = Color.Black;
        richTextBoxPromt.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBoxPromt.ForeColor = Color.Gainsboro;
        richTextBoxPromt.Location = new Point(0, 0);
        richTextBoxPromt.Name = "richTextBoxPromt";
        richTextBoxPromt.Size = new Size(1134, 136);
        richTextBoxPromt.TabIndex = 9;
        richTextBoxPromt.Text = "";
        richTextBoxPromt.KeyDown += richTextBoxPromt_KeyDown;
        // 
        // richTextBox2
        // 
        richTextBox2.BackColor = Color.Black;
        richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        richTextBox2.ForeColor = Color.Gainsboro;
        richTextBox2.Location = new Point(0, 0);
        richTextBox2.Name = "richTextBox2";
        richTextBox2.ReadOnly = true;
        richTextBox2.Size = new Size(1134, 385);
        richTextBox2.TabIndex = 10;
        richTextBox2.Text = "";
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new Point(0, 40);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(richTextBox2);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(richTextBoxPromt);
        splitContainer1.Size = new Size(1134, 525);
        splitContainer1.SplitterDistance = 385;
        splitContainer1.TabIndex = 11;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(1134, 565);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip);
        Font = new Font("Segoe UI", 12F);
        ForeColor = Color.Gray;
        MainMenuStrip = menuStrip;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        Name = "FormMain";
        Text = "FormMain";
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
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
    private System.Windows.Forms.ToolStripMenuItem buttonWSL;
    private System.Windows.Forms.RichTextBox richTextBoxPromt;
    private System.Windows.Forms.RichTextBox richTextBox2;
    private System.Windows.Forms.SplitContainer splitContainer1;
}
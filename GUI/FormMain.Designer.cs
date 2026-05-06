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
        listViewTasks = new System.Windows.Forms.ListView();
        label1 = new System.Windows.Forms.Label();
        buttonStart = new System.Windows.Forms.Button();
        buttonChangeApiKey = new System.Windows.Forms.Button();
        buttonClearHistory = new System.Windows.Forms.Button();
        buttonWSL = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // listViewTasks
        // 
        listViewTasks.Location = new Point(13, 52);
        listViewTasks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        listViewTasks.Name = "listViewTasks";
        listViewTasks.Size = new Size(994, 529);
        listViewTasks.TabIndex = 0;
        listViewTasks.UseCompatibleStateImageBehavior = false;
        listViewTasks.View = System.Windows.Forms.View.List;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(113, 38);
        label1.TabIndex = 1;
        label1.Text = "Задачи:";
        // 
        // buttonStart
        // 
        buttonStart.Enabled = false;
        buttonStart.Location = new Point(12, 589);
        buttonStart.Name = "buttonStart";
        buttonStart.Size = new Size(384, 50);
        buttonStart.TabIndex = 4;
        buttonStart.Text = "Запуск";
        buttonStart.UseVisualStyleBackColor = true;
        buttonStart.Click += buttonStart_Click;
        // 
        // buttonChangeApiKey
        // 
        buttonChangeApiKey.Location = new Point(708, 589);
        buttonChangeApiKey.Name = "buttonChangeApiKey";
        buttonChangeApiKey.Size = new Size(300, 50);
        buttonChangeApiKey.TabIndex = 5;
        buttonChangeApiKey.Text = "Изменить api ключ";
        buttonChangeApiKey.UseVisualStyleBackColor = true;
        buttonChangeApiKey.Click += buttonChangeApiKey_Click;
        // 
        // buttonClearHistory
        // 
        buttonClearHistory.Location = new Point(708, 645);
        buttonClearHistory.Name = "buttonClearHistory";
        buttonClearHistory.Size = new Size(300, 50);
        buttonClearHistory.TabIndex = 6;
        buttonClearHistory.Text = "Очистить историю";
        buttonClearHistory.UseVisualStyleBackColor = true;
        buttonClearHistory.Click += buttonClearHistory_Click;
        // 
        // buttonWSL
        // 
        buttonWSL.Location = new Point(402, 589);
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
        ClientSize = new Size(1020, 704);
        Controls.Add(buttonWSL);
        Controls.Add(buttonClearHistory);
        Controls.Add(buttonChangeApiKey);
        Controls.Add(buttonStart);
        Controls.Add(label1);
        Controls.Add(listViewTasks);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        Name = "FormMain";
        Text = "FormMain";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.ListView listViewTasks;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.Button buttonChangeApiKey;
    private System.Windows.Forms.Button buttonClearHistory;
    private System.Windows.Forms.Button buttonWSL;
}
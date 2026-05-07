namespace DeepSeekAgent.UI;

partial class SideTabControl
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
        panel1 = new System.Windows.Forms.Panel();
        tabs = new System.Windows.Forms.FlowLayoutPanel();
        panelContent = new System.Windows.Forms.Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(tabs);
        panel1.Dock = System.Windows.Forms.DockStyle.Right;
        panel1.Location = new System.Drawing.Point(756, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(300, 598);
        panel1.TabIndex = 0;
        // 
        // tabs
        // 
        tabs.AutoScroll = true;
        tabs.Dock = System.Windows.Forms.DockStyle.Fill;
        tabs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        tabs.Location = new System.Drawing.Point(0, 0);
        tabs.Name = "tabs";
        tabs.Size = new System.Drawing.Size(300, 598);
        tabs.TabIndex = 0;
        tabs.WrapContents = false;
        // 
        // panelContent
        // 
        panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
        panelContent.Location = new System.Drawing.Point(0, 0);
        panelContent.Name = "panelContent";
        panelContent.Size = new System.Drawing.Size(756, 598);
        panelContent.TabIndex = 1;
        // 
        // LeftTabControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
        Controls.Add(panelContent);
        Controls.Add(panel1);
        Font = new System.Drawing.Font("Cascadia Mono", 12F);
        ForeColor = System.Drawing.Color.Gainsboro;
        Margin = new System.Windows.Forms.Padding(4);
        Name = "LeftTabControl";
        Size = new System.Drawing.Size(1056, 598);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panelContent;
    private System.Windows.Forms.FlowLayoutPanel tabs;
}

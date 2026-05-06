namespace DeepSeekAgent.GUI;

partial class FormStartPromt
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
        buttonCancel = new System.Windows.Forms.Button();
        richTextBoxPromt = new System.Windows.Forms.RichTextBox();
        SuspendLayout();
        // 
        // buttonStart
        // 
        buttonStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        buttonStart.Location = new System.Drawing.Point(12, 558);
        buttonStart.Name = "buttonStart";
        buttonStart.Size = new System.Drawing.Size(189, 60);
        buttonStart.TabIndex = 0;
        buttonStart.Text = "Старт";
        buttonStart.UseVisualStyleBackColor = true;
        buttonStart.Click += buttonStart_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        buttonCancel.Location = new System.Drawing.Point(207, 558);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new System.Drawing.Size(189, 60);
        buttonCancel.TabIndex = 1;
        buttonCancel.Text = "Отмена";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // richTextBoxPromt
        // 
        richTextBoxPromt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        richTextBoxPromt.Location = new System.Drawing.Point(12, 12);
        richTextBoxPromt.Name = "richTextBoxPromt";
        richTextBoxPromt.Size = new System.Drawing.Size(789, 540);
        richTextBoxPromt.TabIndex = 2;
        richTextBoxPromt.Text = "";
        // 
        // FormStartPromt
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(813, 630);
        Controls.Add(richTextBoxPromt);
        Controls.Add(buttonCancel);
        Controls.Add(buttonStart);
        Font = new System.Drawing.Font("Segoe UI", 14F);
        Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        Name = "FormStartPromt";
        Text = "Введите промт задачи";
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.RichTextBox richTextBoxPromt;
}
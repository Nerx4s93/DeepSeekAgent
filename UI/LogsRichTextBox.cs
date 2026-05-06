using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DeepSeekAgent.UI;

public class LogsRichTextBox : FastRichTextBox
{
    public void LogLine(string text = "", Color? color = null)
    {
        Log(text + "\n", color);
    }

    public void Log(string text, Color? color = null)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => AppendRtf(text, color)));
        }
        else
        {
            AppendRtf(text, color);
        }
    }

    private void AppendRtf(string text, Color? color)
    {
        SuspendLayout();

        try
        {
            var isAtBottom = IsScrolledToBottom();

            SelectionStart = TextLength;
            SelectionColor = color ?? ForeColor;
            AppendText(text);

            if (isAtBottom)
            {
                ScrollToBottom();
            }    
        }
        finally
        {
            ResumeLayout();
        }
    }

    private bool IsScrolledToBottom()
    {
        var lastVisible = GetCharIndexFromPosition(new Point(0, Height));
        return lastVisible >= TextLength - 1;
    }

    private void ScrollToBottom()
    {
        SendMessage(Handle, WM_VSCROLL, SB_BOTTOM, 0);
    }

    private const int EM_GETFIRSTVISIBLELINE = 0x00CE;
    private const int WM_VSCROLL = 0x0115;
    private const int SB_BOTTOM = 7;

    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
}
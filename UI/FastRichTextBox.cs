using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DeepSeekAgent.UI;

public class FastRichTextBox : RichTextBox
{
    private const int WM_MOUSEWHEEL = 0x020A;
    private const int EM_LINESCROLL = 0x00B6;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_MOUSEWHEEL)
        {
            var wParam = m.WParam.ToInt64();
            var delta = (short)((wParam >> 16) & 0xffff);

            var linesPerNotch = SystemInformation.MouseWheelScrollLines;
            var steps = delta / 120;

            var scrollLines = -steps * linesPerNotch;

            SendMessage(this.Handle, EM_LINESCROLL, IntPtr.Zero, (IntPtr)scrollLines);
            return;
        }

        base.WndProc(ref m);
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
}
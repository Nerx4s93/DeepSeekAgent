using System;
using System.Drawing;

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
            SelectionStart = TextLength;
            SelectionColor = color ?? ForeColor;
            AppendText(text);
        }
        finally
        {
            ResumeLayout();
        }
    }

    private string ConvertToRtf(string text, Color? color)
    {
        var stringBuilder = new System.Text.StringBuilder();

        stringBuilder.Append(@"{\rtf1\ansi");

        if (color.HasValue)
        {
            var colorValue = color.Value;
            stringBuilder.Append(@"{\colortbl ;");
            stringBuilder.Append($@"\red{colorValue.R}\green{colorValue.G}\blue{colorValue.B};");
            stringBuilder.Append("}");
            stringBuilder.Append($@"\cf1 {EscapeRtf(text)}");
        }
        else
        {
            stringBuilder.Append(EscapeRtf(text));
        }

        stringBuilder.Append("}");

        return stringBuilder.ToString();
    }

    private string EscapeRtf(string text)
    {
        return text
            .Replace(@"\", @"\\")
            .Replace("{", @"\{")
            .Replace("}", @"\}")
            .Replace("\n", @"\par ");
    }
}

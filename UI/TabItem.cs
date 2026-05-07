using System.Windows.Forms;

namespace DeepSeekAgent.UI;

public class TabItem
{
    public TabItem(string text, TabNavigationButton button, Control content)
    {
        Text = text;
        Button = button;
        Content = content;
    }

    public string Text { get; set; }
    public TabNavigationButton Button { get; set; }
    public Control Content { get; set; }
    public object? Tag { get; set; }
}
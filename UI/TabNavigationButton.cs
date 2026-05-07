using System.Drawing;
using System.Windows.Forms;

namespace DeepSeekAgent.UI;

public class TabNavigationButton : Button
{
    public TabNavigationButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;

        FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
        FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);

        BackColor = Color.FromArgb(45, 45, 45);
        ForeColor = Color.White;

        TabStop = false;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            BackColor = Color.FromArgb(70, 70, 70);
        }
        else
        {
            BackColor = Color.FromArgb(45, 45, 45);
        }
    }
}
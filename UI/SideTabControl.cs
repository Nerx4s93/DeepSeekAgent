using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace DeepSeekAgent.UI;

[ToolboxItem(false)]
public partial class SideTabControl : UserControl
{
    private readonly List<TabItem> _tabs = [];
    private TabItem? _selectedTab;

    public SideTabControl()
    {
        InitializeComponent();
    }

    public IReadOnlyList<TabItem> Tabs => _tabs;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TabItem? SelectedTab
    {
        get => _selectedTab;
        set
        {
            if (_selectedTab == value)
            {
                return;
            }

            _selectedTab = value;
            UpdateSelection();
        }
    }

    public TabItem AddTab(string text)
    {
        var button = new TabNavigationButton
        {
            Text = text,
            AutoSize = false,
            Height = 40,
            Width = tabs.ClientSize.Width,
            Margin = new Padding(0)
        };

        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            Visible = false
        };

        var tabItem = new TabItem(text, button, panel);

        button.Tag = tabItem;
        button.Click += Button_Click;

        tabs.Controls.Add(button);
        panelContent.Controls.Add(panel);

        _tabs.Add(tabItem);


        tabs.BeginInvoke(new Action(() =>
        {
            if (SelectedTab == null)
            {
                SelectedTab = tabItem;
            }
        }));

        return tabItem;
    }

    private void UpdateSelection()
    {
        foreach (var tab in _tabs)
        {
            var active = tab == _selectedTab;

            tab.Button.Enabled = !active;
            tab.Button.SetActive(active);

            tab.Content.Visible = active;
        }
    }

    private void Button_Click(object? sender, EventArgs e)
    {
        if (sender is TabNavigationButton button && button.Tag is TabItem tab)
        {
            SelectedTab = tab;
        }
    }
}
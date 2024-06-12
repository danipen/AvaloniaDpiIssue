using Avalonia.Controls;

namespace AvaloniaDpiIssue;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // create a button that displays a modal dialog
        var button = new Button
        {
            Content = "Show Dialog",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top
        };

        this.Content = button;

        button.Click += (_, _) =>
        {
            var dialog = new ChildWindow();
            dialog.ShowDialog(this);
        };
    }

    class ChildWindow : Window
    {
        internal ChildWindow()
        {
            Title = "Dialog";
            Width = 300;
            CanResize = false;
            SizeToContent = SizeToContent.Height;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            DockPanel contentPanel = new DockPanel();
            contentPanel.Margin = new Avalonia.Thickness(20);

            Panel headerPanel = new Panel();
            headerPanel.Margin = new Avalonia.Thickness(5);
            Panel bodyPanel = new Panel();
            bodyPanel.Margin = new Avalonia.Thickness(25);
            Panel buttonsPanel = new Panel();
            buttonsPanel.Margin = new Avalonia.Thickness(5);

            var headerText = new TextBlock
            {
                Text = "This is a dialog",
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };

            var bodyText = new TextBlock
            {
                Text = "This is the body of the dialog",
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };

            var button = new Button
            {
                Content = "Close",
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };

            button.Click += (_, _) =>
            {
                Close();
            };

            headerPanel.Children.Add(headerText);
            bodyPanel.Children.Add(bodyText);
            buttonsPanel.Children.Add(button);

            DockPanel.SetDock(headerPanel, Dock.Top);
            DockPanel.SetDock(buttonsPanel, Dock.Bottom);

            contentPanel.Children.Add(headerPanel);
            contentPanel.Children.Add(buttonsPanel);
            contentPanel.Children.Add(bodyPanel);

            this.Content = contentPanel;
        }
    }
}
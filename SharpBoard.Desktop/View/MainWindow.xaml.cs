using MoreLinq;
using SharpBoard.Domain;
using System.Windows;
using Xceed.Wpf.AvalonDock.Controls;

namespace SharpBoard.Desktop.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            Loaded += OnLoaded;
            InitializeComponent();

            KeyboardSelector.ItemsSource = KeyboardKind.List;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) =>
            this.FindVisualChildren<KeyControl>()
                .ForEach(kc => kc.KeyClicked += keyValue => CurrentKeyControlUi.CurrentKeyValue = keyValue);
    }
}

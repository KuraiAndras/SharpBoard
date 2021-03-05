using System.Windows;
using MoreLinq;
using Xceed.Wpf.AvalonDock.Controls;

namespace SharpBoard.Desktop.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            Loaded += OnLoaded;
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e) =>
            this.FindVisualChildren<KeyControl>()
                .ForEach(kc => kc.KeyClicked += keyValue => CurrentKeyControlUi.CurrentKeyValue = keyValue);
    }
}

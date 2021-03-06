using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SharpBoard.Desktop.View
{
    public partial class KeyControl : INotifyPropertyChanged
    {
        private int _tesoroLedId;

        public int KeyValue
        {
            get => _tesoroLedId;
            set => SetAndNotifyProperty(ref _tesoroLedId, value);
        }

        public KeyControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event Action<int>? KeyClicked;

        private void OnButtonClicked(object _, RoutedEventArgs __) => KeyClicked?.Invoke(KeyValue);

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetAndNotifyProperty<T>(ref T? backingField, T value, [CallerMemberName] string? propertyName = null)
        {
            if (backingField?.Equals(value) == true) return;

            backingField = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

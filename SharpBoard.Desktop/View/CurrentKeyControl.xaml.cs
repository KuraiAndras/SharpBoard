using Injecter;
using MediatR;
using SharpBoard.Desktop.Extensions;
using SharpBoard.Domain.Keyboards;
using SharpBoard.KeysApi;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SharpBoard.Desktop.View
{
    public sealed partial class CurrentKeyControl : INotifyPropertyChanged
    {
        [Inject] private readonly IMediator _mediator = default!;

        private int _tesoroLedId;

        public int CurrentKeyValue
        {
            get => _tesoroLedId;
            set => SetAndNotifyProperty(ref _tesoroLedId, value);
        }

        private KeyboardKind? _currentKeyboard;

        public KeyboardKind CurrentKeyboard
        {
            get => _currentKeyboard ?? KeyboardKind.None;
            set => SetAndNotifyProperty(ref _currentKeyboard, value);
        }

        public CurrentKeyControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        private async void OnApplyClicked(object sender, RoutedEventArgs e)
        {
            var keyColor = KeyColorPicker.SelectedColor.ToRgb256();

            await ApplyButton.DisableForRun(
                () => _mediator.Send(new SetKeyColor(keyColor, CurrentKeyValue, CurrentKeyboard)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetAndNotifyProperty<T>(ref T? backingField, T value, [CallerMemberName] string? propertyName = null)
        {
            if (backingField?.Equals(value) == true) return;

            backingField = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

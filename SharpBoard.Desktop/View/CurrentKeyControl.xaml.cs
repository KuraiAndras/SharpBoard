using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Injecter;
using MediatR;
using SharpBoard.Desktop.Extensions;
using SharpBoard.Desktop.Requests;
using TesoroRgb.Core;

namespace SharpBoard.Desktop.View
{
    public sealed partial class CurrentKeyControl : INotifyPropertyChanged
    {
        [Inject] private readonly IMediator _mediator = default!;

        private TesoroLedId _tesoroLedId = TesoroLedId.Escape;

        public TesoroLedId CurrentKeyValue
        {
            get => _tesoroLedId;
            set => SetAndNotifyProperty(ref _tesoroLedId, value);
        }

        public CurrentKeyControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        private async void OnApplyClicked(object sender, RoutedEventArgs e)
        {
            var keyColor = KeyColorPicker.SelectedColor.ToRgb256();

            await _mediator.Send(new SetKeyColor(keyColor, CurrentKeyValue));
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

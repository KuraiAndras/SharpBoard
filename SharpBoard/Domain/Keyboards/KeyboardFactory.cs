using Microsoft.Extensions.DependencyInjection;
using System;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class KeyboardFactory : IKeyboardFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public KeyboardFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public IKeyboard CreateKeyboard(KeyboardKind keyboard) => keyboard switch
        {
            KeyboardKind.Tesoro => _serviceProvider.GetRequiredService<TesoroKeyboard>(),
            KeyboardKind.Redragon => _serviceProvider.GetRequiredService<RedragonKeyboard>(),
            _ => throw new ArgumentOutOfRangeException(nameof(keyboard), keyboard, "Unhandled Keyboard Kind")
        };
    }
}

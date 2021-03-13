using Microsoft.Extensions.DependencyInjection;
using System;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class KeyboardFactory : IKeyboardFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public KeyboardFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public IKeyBoard Create(KeyboardKind keyboardKind) => keyboardKind switch
        {
            KeyboardKind.None => _serviceProvider.GetRequiredService<None>(),
            KeyboardKind.Tesoro => _serviceProvider.GetRequiredService<Tesoro>(),
            KeyboardKind.Redragon => _serviceProvider.GetRequiredService<Redragon>(),
            _ => throw new ArgumentOutOfRangeException(nameof(keyboardKind), keyboardKind, null)
        };
    }
}

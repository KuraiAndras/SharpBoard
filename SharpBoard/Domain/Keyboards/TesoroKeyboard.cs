using System.Threading;
using System.Threading.Tasks;
using TesoroRgb.Core;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class TesoroKeyboard : IKeyboard
    {
        private readonly Keyboard _keyboard;

        public TesoroKeyboard(Keyboard keyboard) => _keyboard = keyboard;

        public async Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
        {
            var (r, g, b) = color;

            await _keyboard.SetKeyColorAsync(keyId, r, g, b, TesoroProfile.Pc, cancellationToken: cancellationToken);

            await _keyboard.SaveSpectrumColorsAsync(TesoroProfile.Pc, cancellationToken: cancellationToken);
        }
    }
}

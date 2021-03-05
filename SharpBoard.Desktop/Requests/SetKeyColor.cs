using MediatR;
using SharpBoard.Desktop.Models;
using System.Threading;
using System.Threading.Tasks;
using TesoroRgb.Core;

namespace SharpBoard.Desktop.Requests
{
    public record SetKeyColor(ColorRgb256 ColorValue, TesoroLedId LedId) : IRequest
    {
        public sealed class Handler : IRequestHandler<SetKeyColor, Unit>
        {
            private readonly Keyboard _keyboard;

            public Handler(Keyboard keyboard) => _keyboard = keyboard;

            public async Task<Unit> Handle(SetKeyColor request, CancellationToken cancellationToken)
            {
                var (colorValue, ledId) = request;
                var (r, g, b) = colorValue;

                await _keyboard.SetKeyColorAsync(ledId, r, g, b, TesoroProfile.Pc, cancellationToken: cancellationToken);

                await _keyboard.SaveSpectrumColorsAsync(TesoroProfile.Pc, cancellationToken: cancellationToken);

                return Unit.Value;
            }
        }
    }
}

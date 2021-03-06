using MediatR;
using SharpBoard.Domain;
using SharpBoard.Domain.Keyboards;
using System.Threading;
using System.Threading.Tasks;
using TesoroRgb.Core;

namespace SharpBoard.KeysApi
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S3903:Types should be defined in named namespaces", Justification = "False Positive")]
    public record SetKeyColor(ColorRgb256 ColorValue, TesoroLedId LedId) : IRequest
    {
        public sealed class Handler : IRequestHandler<SetKeyColor, Unit>
        {
            private readonly IKeyboard _keyboard;

            public Handler(IKeyboard keyboard) => _keyboard = keyboard;

            public async Task<Unit> Handle(SetKeyColor request, CancellationToken cancellationToken)
            {
                await _keyboard.SetColorValue(request.ColorValue, (int)request.LedId, cancellationToken);

                return Unit.Value;
            }
        }
    }
}

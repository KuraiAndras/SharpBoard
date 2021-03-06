using MediatR;
using SharpBoard.Domain;
using SharpBoard.Domain.Keyboards;
using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.KeysApi
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S3903:Types should be defined in named namespaces", Justification = "False Positive")]
    public record SetKeyColor(ColorRgb256 ColorValue, int KeyId, KeyboardKind Keyboard) : IRequest
    {
        public sealed class Handler : IRequestHandler<SetKeyColor, Unit>
        {
            public async Task<Unit> Handle(SetKeyColor request, CancellationToken cancellationToken)
            {
                var (color, keyId, keyboard) = request;

                await keyboard.SetColorValue(color, keyId, cancellationToken);

                // TODO: Persist keyboard state

                return Unit.Value;
            }
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public abstract partial class KeyboardKind
    {
        private sealed class RedragonType : KeyboardKind
        {
            public RedragonType() : base(nameof(Redragon), 2)
            {
            }

            public override Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
            {
                // TODO: Implement this

                return Task.CompletedTask;
            }
        }
    }
}

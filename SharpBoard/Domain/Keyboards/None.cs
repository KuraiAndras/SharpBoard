using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public abstract partial class KeyboardKind
    {
        private sealed class NoneType : KeyboardKind
        {
            public NoneType() : base(nameof(None), 0)
            {
            }

            public override Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default) => Task.CompletedTask;
        }
    }
}

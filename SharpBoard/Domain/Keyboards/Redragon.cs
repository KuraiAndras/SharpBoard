using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class Redragon : IKeyBoard
    {
        public Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
        {
            // TODO: Implement this

            return Task.CompletedTask;
        }
    }
}

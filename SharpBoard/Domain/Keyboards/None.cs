using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class None : IKeyBoard
    {
        public Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}

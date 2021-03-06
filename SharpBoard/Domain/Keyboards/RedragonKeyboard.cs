using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class RedragonKeyboard : IKeyboard
    {
        public Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }
}

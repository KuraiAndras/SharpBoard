using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public interface IKeyboard
    {
        Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default);
    }
}

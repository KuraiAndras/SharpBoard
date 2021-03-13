using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public interface IKeyBoard
    {
        Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default);
    }
}

using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class RedragonKeyboard : IKeyboard
    {
        private readonly ILogger<RedragonKeyboard> _logger;

        public RedragonKeyboard(ILogger<RedragonKeyboard> logger) => _logger = logger;

        public Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
        {
            _logger.LogError("Setting key color is not implemented {KeyId}", keyId);

            return Task.CompletedTask;
        }
    }
}

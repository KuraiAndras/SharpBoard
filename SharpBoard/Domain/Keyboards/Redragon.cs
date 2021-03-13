using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class Redragon : IKeyBoard
    {
        private readonly ILogger<Redragon> _logger;

        public Redragon(ILogger<Redragon> logger) => _logger = logger;

        public Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
        {
            _logger.LogError("Pressed key {KeyId} with color {Color} is not implemented", keyId, color);

            // TODO: Implement this

            return Task.CompletedTask;
        }
    }
}

using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public sealed class None : IKeyBoard
    {
        private readonly ILogger<None> _logger;

        public None(ILogger<None> logger) => _logger = logger;

        public Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Pressed key {KeyId} with color {Color}", keyId, color);

            return Task.CompletedTask;
        }
    }
}

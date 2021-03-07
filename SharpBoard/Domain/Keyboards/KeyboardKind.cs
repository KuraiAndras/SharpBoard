using Ardalis.SmartEnum;
using System.Threading;
using System.Threading.Tasks;

namespace SharpBoard.Domain.Keyboards
{
    public abstract partial class KeyboardKind : SmartEnum<KeyboardKind>
    {
        public static readonly KeyboardKind None = new NoneType();
        public static readonly KeyboardKind Tesoro = new TesoroType();
        public static readonly KeyboardKind Redragon = new RedragonType();

        private KeyboardKind(string name, int value) : base(name, value)
        {
        }

        public abstract Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default);
    }
}

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TesoroRgb.Core;

namespace SharpBoard.Desktop.View.ValueConverters
{
    public sealed class LedIdToText : ValueConverter<TesoroLedId, string>
    {
        private static readonly ImmutableDictionary<TesoroLedId, string> _ledNames = new Dictionary<TesoroLedId, string>
            {
                { TesoroLedId.Escape, "Escape" },
                { TesoroLedId.F1, "F1" },
                { TesoroLedId.F2, "F2" },
                { TesoroLedId.F3, "F3" },
                { TesoroLedId.F4, "F4" },
                { TesoroLedId.F5, "F5" },
                { TesoroLedId.F6, "F6" },
                { TesoroLedId.F7, "F7" },
                { TesoroLedId.F8, "F8" },
                { TesoroLedId.F9, "F9" },
                { TesoroLedId.F10, "F10" },
                { TesoroLedId.F11, "F11" },
                { TesoroLedId.F12, "F12" },
                { TesoroLedId.PrintScreen, "Print Screen" },
                { TesoroLedId.ScrollLock, "Scroll Lock" },
                { TesoroLedId.Pause, "Pause" },

                { TesoroLedId.D0, "0" },
                { TesoroLedId.D1, "1" },
                { TesoroLedId.D2, "2" },
                { TesoroLedId.D3, "3" },
                { TesoroLedId.D4, "4" },
                { TesoroLedId.D5, "5" },
                { TesoroLedId.D6, "6" },
                { TesoroLedId.D7, "7" },
                { TesoroLedId.D8, "8" },
                { TesoroLedId.D9, "9" },
                { TesoroLedId.Back, "Back" },
                { TesoroLedId.Insert, "Insert" },
                { TesoroLedId.Home, "Home" },
                { TesoroLedId.PageUp, "Page Up" },
                { TesoroLedId.NumLock, "Num Lock" },
                { TesoroLedId.Divide, "/" },
                { TesoroLedId.Multiply, "*" },
                { TesoroLedId.Subtract, "-" },
            }
            .ToImmutableDictionary();

        protected override string Convert(TesoroLedId source) => _ledNames[source];

        protected override TesoroLedId ConvertBack(string value) => _ledNames.First(n => n.Value == value).Key;
    }
}

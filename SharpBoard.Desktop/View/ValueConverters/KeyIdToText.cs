using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SharpBoard.Desktop.View.ValueConverters
{
    public sealed class KeyIdToText : ValueConverter<int, string>
    {
        private static readonly ImmutableDictionary<int, string> _ledNames = new Dictionary<int, string>
            {
                { 0, "Escape" },
                { 1, "F1" },
                { 2, "F2" },
                { 3, "F3" },
                { 4, "F4" },
                { 5, "F5" },
                { 6, "F6" },
                { 7, "F7" },
                { 8, "F8" },
                { 9, "F9" },
                { 10, "F10" },
                { 11, "F11" },
                { 12, "F12" },
                { 13, "Print Screen" },
                { 14, "Scroll Lock" },
                { 15, "Pause" },

                { 16, "0" },
                { 17, "1" },
                { 18, "2" },
                { 19, "3" },
                { 20, "4" },
                { 21, "5" },
                { 22, "6" },
                { 23, "7" },
                { 24, "8" },
                { 25, "9" },
                { 26, "Back" },
                { 27, "Insert" },
                { 28, "Home" },
                { 29, "Page Up" },
                { 30, "Num Lock" },
                { 31, "/" },
                { 32, "*" },
                { 33, "-" },
            }
            .ToImmutableDictionary();

        protected override string Convert(int source) => _ledNames[source];

        protected override int ConvertBack(string value) => _ledNames.First(n => n.Value == value).Key;
    }
}

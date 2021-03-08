﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SharpBoard.Desktop.View.ValueConverters
{
    public sealed class KeyIdToText : ValueConverter<int, string>
    {
        private static readonly ImmutableDictionary<int, string> _ledNames = new Dictionary<int, string>
            {
                // First Row
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
                // Second Row
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
                { 26, "Ö" },
                { 27, "Ü" },
                { 28, "Ó" },
                { 29, "Back" },
                { 30, "Insert" },
                { 31, "Home" },
                { 32, "Page Up" },
                { 33, "Num Lock" },
                { 34, "/" },
                { 35, "*" },
                { 36, "-" },
                // Third Row
                { 37, "Tab" },
                { 38, "Q" },
                { 39, "W" },
                { 40, "E" },
                { 41, "R" },
                { 42, "T" },
                { 43, "Z" },
                { 44, "U" },
                { 45, "I" },
                { 46, "O" },
                { 47, "P" },
                { 48, "Ő" },
                { 49, "Ú" },
                { 50, "Delete" },
                { 51, "End" },
                { 52, "Page Down" },
                { 53, "7" },
                { 54, "8" },
                { 55, "9" },
                { 56, "+" },
                // Fourth Row
                { 57, "Caps Lock" },
                { 58, "A" },
                { 59, "S" },
                { 60, "D" },
                { 61, "F" },
                { 62, "G" },
                { 63, "H" },
                { 64, "J" },
                { 65, "K" },
                { 66, "L" },
                { 67, "É" },
                { 68, "Á" },
                { 69, "Ű" },
                { 70, "Enter" },
                { 71, "4" },
                { 72, "5" },
                { 73, "6" },
                // Fifth Row
                { 74, "Left Shift" },
                { 75, "Í" },
                { 76, "Y" },
                { 77, "X" },
                { 78, "C" },
                { 79, "V" },
                { 80, "B" },
                { 81, "N" },
                { 82, "M" },
                { 83, "," },
                { 84, "." },
                { 85, "-" },
                { 86, "Right Shift" },
                { 87, "Up" },
                { 88, "1" },
                { 89, "2" },
                { 90, "3" },
                { 91, "Enter" },
                // Sixth Row
                { 92, "Left Control" },
                { 93, "Windows" },
                { 94, "Alt" },
                { 95, "Space" },
                { 96, "AltGr" },
                { 97, "FN" },
                { 98, "Info" },
                { 99, "Right Control" },
                { 100, "Left" },
                { 101, "Down" },
                { 102, "Right" },
                { 103, "0" },
                { 104, "." },

                // Additional LEDs
                { 500, "L0"},
                { 501, "L1"},
                { 502, "L2"},
            }
            .ToImmutableDictionary();

        protected override string Convert(int source) => _ledNames[source];

        protected override int ConvertBack(string value) => _ledNames.First(n => n.Value == value).Key;
    }
}

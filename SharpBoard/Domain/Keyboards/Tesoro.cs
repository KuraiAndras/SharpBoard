using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using TesoroRgb.Core;

namespace SharpBoard.Domain.Keyboards
{
    public abstract partial class KeyboardKind
    {
        private sealed class TesoroType : KeyboardKind
        {
            private static readonly ImmutableDictionary<int, TesoroLedId> _ledNames = new Dictionary<int, TesoroLedId>
                {
                    // First Row
                    { 0, TesoroLedId.Escape},
                    { 1, TesoroLedId.F1},
                    { 2, TesoroLedId.F2},
                    { 3, TesoroLedId.F3},
                    { 4, TesoroLedId.F4},
                    { 5, TesoroLedId.F5},
                    { 6, TesoroLedId.F6},
                    { 7, TesoroLedId.F7 },
                    { 8, TesoroLedId.F8},
                    { 9, TesoroLedId.F9},
                    { 10, TesoroLedId.F10},
                    { 11, TesoroLedId.F11},
                    { 12, TesoroLedId.F12},
                    { 13, TesoroLedId.PrintScreen},
                    { 14, TesoroLedId.ScrollLock},
                    { 15, TesoroLedId.Pause},
                    // Second Row
                    { 16, TesoroLedId.Oemtilde},
                    { 17, TesoroLedId.D1},
                    { 18, TesoroLedId.D2},
                    { 19, TesoroLedId.D3},
                    { 20, TesoroLedId.D4},
                    { 21, TesoroLedId.D5},
                    { 22, TesoroLedId.D6},
                    { 23, TesoroLedId.D7},
                    { 24, TesoroLedId.D8},
                    { 25, TesoroLedId.D9},
                    { 26, TesoroLedId.D0},
                    { 27, TesoroLedId.OemMinus},
                    { 28, TesoroLedId.OemPlus},
                    { 29, TesoroLedId.Back},
                    { 30, TesoroLedId.Insert},
                    { 31, TesoroLedId.Home},
                    { 32, TesoroLedId.PageUp},
                    { 33, TesoroLedId.NumLock},
                    { 34, TesoroLedId.Divide},
                    { 35, TesoroLedId.Multiply},
                    { 36, TesoroLedId.Subtract},
                    // Third Row
                    { 37, TesoroLedId.Tab },
                    { 38, TesoroLedId.Q },
                    { 39, TesoroLedId.W },
                    { 40, TesoroLedId.E },
                    { 41, TesoroLedId.R },
                    { 42, TesoroLedId.T },
                    { 43, TesoroLedId.Y },
                    { 44, TesoroLedId.U },
                    { 45, TesoroLedId.I },
                    { 46, TesoroLedId.O },
                    { 47, TesoroLedId.P},
                    { 48, TesoroLedId.OemOpenBrackets },
                    { 49, TesoroLedId.OemCloseBrackets },
                    { 50, TesoroLedId.Delete },
                    { 51, TesoroLedId.End },
                    { 52, TesoroLedId.PageDown },
                    { 53, TesoroLedId.NumPad7 },
                    { 54, TesoroLedId.NumPad8 },
                    { 55, TesoroLedId.NumPad9 },
                    { 56, TesoroLedId.Add},
                    // Fourth Row
                    { 57, TesoroLedId.CapsLock },
                    { 58, TesoroLedId.A },
                    { 59, TesoroLedId.S },
                    { 60, TesoroLedId.D },
                    { 61, TesoroLedId.F },
                    { 62, TesoroLedId.G },
                    { 63, TesoroLedId.H },
                    { 64, TesoroLedId.J },
                    { 65, TesoroLedId.K },
                    { 66, TesoroLedId.L },
                    { 67, TesoroLedId.OemSemicolon},
                    { 68, TesoroLedId.Apostrophe },
                    { 69, (TesoroLedId)68 },
                    { 70, TesoroLedId.Enter },
                    { 71, TesoroLedId.NumPad4 },
                    { 72, TesoroLedId.NumPad5 },
                    { 73, TesoroLedId.NumPad6 },
                    // Fifth Row
                    { 74, TesoroLedId.LeftShift },
                    { 75, (TesoroLedId)19 },
                    { 76, TesoroLedId.Z },
                    { 77, TesoroLedId.X },
                    { 78, TesoroLedId.C },
                    { 79, TesoroLedId.V },
                    { 80, TesoroLedId.B },
                    { 81, TesoroLedId.N },
                    { 82, TesoroLedId.M },
                    { 83, TesoroLedId.Comma },
                    { 84, TesoroLedId.Period },
                    { 85, TesoroLedId.Slash },
                    { 86, TesoroLedId.RightShift },
                    { 87, TesoroLedId.Up },
                    { 88, TesoroLedId.NumPad1 },
                    { 89, TesoroLedId.NumPad2 },
                    { 90, TesoroLedId.NumPad3 },
                    { 91, TesoroLedId.NumPadEnter },
                    // Sixth Row
                    { 92, TesoroLedId.LeftControl },
                    { 93, TesoroLedId.Windows },
                    { 94, TesoroLedId.Alt },
                    { 95, TesoroLedId.Space },
                    { 96, TesoroLedId.AltGr },
                    { 97, TesoroLedId.TesoroFn },
                    { 98, TesoroLedId.Apps },
                    { 99, TesoroLedId.RightControl },
                    { 100, TesoroLedId.Left },
                    { 101, TesoroLedId.Down },
                    { 102, TesoroLedId.Right },
                    { 103, TesoroLedId.NumPad0 },
                    { 104, TesoroLedId.Decimal },
                    // Additional LEds
                    { 500, (TesoroLedId)3 },
                    { 501, (TesoroLedId)5 },
                    { 502, (TesoroLedId)73 },
                }
                .ToImmutableDictionary();

            public TesoroType() : base(nameof(Tesoro), 1)
            {
            }

            public override async Task SetColorValue(ColorRgb256 color, int keyId, CancellationToken cancellationToken = default)
            {
                using var keyboard = new Keyboard();

                var initialized = keyboard.Initialize();
                if (!initialized) throw new InvalidOperationException("Cloud not initialize Tesoro keyboard");

                var (r, g, b) = color;

                var tesoroKeyId = _ledNames[keyId];

                await Task.Run(() =>
                {
                    keyboard.SetProfile(TesoroProfile.Pc);
                    Thread.Sleep(100);

                    keyboard.SetKeyColor(tesoroKeyId, r, g, b, TesoroProfile.Pc);
                    Thread.Sleep(1);

                    keyboard.SaveSpectrumColors(TesoroProfile.Pc);
                }, cancellationToken);

                await Task.Delay(100, cancellationToken);
            }
        }
    }
}

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

                    { 16, TesoroLedId.D0},
                    { 17, TesoroLedId.D1},
                    { 18, TesoroLedId.D2},
                    { 19, TesoroLedId.D3},
                    { 20, TesoroLedId.D4},
                    { 21, TesoroLedId.D5},
                    { 22, TesoroLedId.D6},
                    { 23, TesoroLedId.D7},
                    { 24, TesoroLedId.D8},
                    { 25, TesoroLedId.D9},
                    { 26, TesoroLedId.Back},
                    { 27, TesoroLedId.Insert},
                    { 28, TesoroLedId.Home},
                    { 29, TesoroLedId.PageUp},
                    { 30, TesoroLedId.NumLock},
                    { 31, TesoroLedId.Divide},
                    { 32, TesoroLedId.Multiply},
                    { 33, TesoroLedId.Subtract},
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

using SharpBoard.Desktop.Models;
using System.Windows.Media;

namespace SharpBoard.Desktop.Extensions
{
    public static class MediaColorExtensions
    {
        public static ColorRgb256 ToRgb256(this Color? color)
        {
            var selectedColor = color ?? new Color
            {
                R = 255,
                G = 255,
                B = 255,
                A = 255,
            };

            var (nR, nG, nB, nA) =
            (
                selectedColor.R / 255f,
                selectedColor.G / 255f,
                selectedColor.B / 255f,
                selectedColor.A / 255f
            );

            return new ColorRgb256
            (
                (int)(((1 - nA) * nR) + (nA * nR * 255)),
                (int)(((1 - nA) * nG) + (nA * nG * 255)),
                (int)(((1 - nA) * nB) + (nA * nB * 255))
            );
        }
    }
}

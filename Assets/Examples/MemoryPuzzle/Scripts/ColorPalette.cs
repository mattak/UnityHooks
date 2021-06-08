using UnityEngine;

namespace Examples.MemoryPuzzle.Scripts
{
    public enum ColorPalette
    {
        Blue,
        Green,
        Red,
        Orange,
        Pink,
        Black,
    }

    public static class ColorPaletteExtension
    {
        public static Color GetColor(this ColorPalette palette)
        {
            switch (palette)
            {
                case ColorPalette.Blue: return ConvertHex(0x00A1FF);
                case ColorPalette.Green: return ConvertHex(0x60D937);
                case ColorPalette.Red: return ConvertHex(0xED220D);
                case ColorPalette.Orange: return ConvertHex(0xFEAE00);
                case ColorPalette.Pink: return ConvertHex(0xFF42A1);
                case ColorPalette.Black: return ConvertHex(0x3D3D3D);
                default: return ConvertHex(0x000000);
            }
        }

        private static Color ConvertHex(int hex)
        {
            var r = (hex & 0xff0000) >> 16;
            var g = (hex & 0x00ff00) >> 8;
            var b = hex & 0x0000ff;
            return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
        }
    }
}
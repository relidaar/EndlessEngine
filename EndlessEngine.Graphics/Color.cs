namespace EndlessEngine.Graphics
{
    public class Color
    {
        public (int r, int g, int b, int a) Values => (R, G, B, A);
        public int[] ValuesArray => new[] {R, G, B, A};
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int A { get; }

        public (float r, float g, float b, float a) ToNormalized()
        {
            return (R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f);
        }

        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        #region Predefined Values

        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);
        public static readonly Color Yellow = new Color(255, 255, 0);
        public static readonly Color Magenta = new Color(255, 0, 255);
        public static readonly Color Cyan = new Color(0, 255, 255);
        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        #endregion

        #region Constructors

        public Color(int r, int g, int b, int a = 255)
        {
            R = Mod(r, 256);
            G = Mod(g, 256);
            B = Mod(b, 256);
            A = Mod(a, 256);
        }

        public Color(int n)
            : this(n, n, n, n)
        {
        }

        public Color(Color color)
            : this(color.R, color.G, color.B, color.A)
        {
        }

        #endregion

        #region Operations

        public Color Add(Color color)
        {
            return new Color(R + color.R, G + color.G, B + color.B, A + color.A);
        }

        public Color Add(int n)
        {
            return new Color(R + n, G + n, B + n, A + n);
        }

        public Color Subtract(Color color)
        {
            return new Color(R - color.R, G - color.G, B - color.B, A - color.A);
        }

        public Color Subtract(int n)
        {
            return new Color(R - n, G - n, B - n, A - n);
        }

        public Color Multiply(int n)
        {
            return new Color(R * n, G * n, B * n, A * n);
        }

        public Color Divide(int n)
        {
            return new Color(R * n, G * n, B * n, A * n);
        }

        #endregion

        #region Operators

        public static Color operator +(Color color1, Color color2)
        {
            return color1.Add(color2);
        }

        public static Color operator +(Color color, int n)
        {
            return color.Add(n);
        }

        public static Color operator -(Color color1, Color color2)
        {
            return color1.Subtract(color2);
        }

        public static Color operator -(Color color, int n)
        {
            return color.Subtract(n);
        }

        public static Color operator *(Color color, int n)
        {
            return color.Multiply(n);
        }

        public static Color operator /(Color color, int n)
        {
            return color.Divide(n);
        }

        #endregion
    }
}
using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Graphics
{
    public struct Color : IEquatable<Color>
    {
        public (int r, int g, int b, int a) Values => (R, G, B, A);
        public int[] ValuesArray => new[] {R, G, B, A};
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int A { get; }

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

        public Color(in Color color)
            : this(color.R, color.G, color.B, color.A)
        {
        }

        #endregion

        #region Operations

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Add(in Color left, in Color right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Add(in Color left, int right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Subtract(in Color left, in Color right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Subtract(in Color left, int right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Multiply(in Color left, in Color right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Multiply(in Color left, int right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Divide(in Color left, in Color right)
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Divide(in Color left, int right)
        {
            return left / right;
        }

        public (float r, float g, float b, float a) ToNormalized()
        {
            return (R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f);
        }

        public static (float r, float g, float b, float a) Normalize(int r, int g, int b, int a)
        {
            return (r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
        }

        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        #endregion

        #region Operators
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator +(in Color left, in Color right)
        {
            return new Color(
                left.R + right.R, 
                left.G + right.G, 
                left.B + right.B, 
                left.A + right.A
                );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator +(in Color left, int right)
        {
            return new Color(
                left.R + right, 
                left.G + right, 
                left.B + right, 
                left.A + right
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator -(in Color left, in Color right)
        {
            return new Color(
                left.R - right.R, 
                left.G - right.G, 
                left.B - right.B, 
                left.A - right.A
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator -(in Color left, int right)
        {
            return new Color(
                left.R - right, 
                left.G - right, 
                left.B - right, 
                left.A - right
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator *(in Color left, in Color right)
        {
            return new Color(
                left.R * right.R, 
                left.G * right.G, 
                left.B * right.B, 
                left.A * right.A
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator *(in Color left, int right)
        {
            return new Color(
                left.R * right, 
                left.G * right, 
                left.B * right, 
                left.A * right
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator /(in Color left, in Color right)
        {
            return new Color(
                left.R / right.R, 
                left.G / right.G, 
                left.B / right.B, 
                left.A / right.A
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator /(in Color left, int right)
        {
            return new Color(
                left.R / right, 
                left.G / right, 
                left.B / right, 
                left.A / right
            );
        }

        #endregion
        
        #region IEquatable Implementation

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Color other)
        {
            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Color left, Color right)
        {
            return !left.Equals(right);
        }
        
        #endregion
    }
}
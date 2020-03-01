﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessEngine.Graphics
{
    public class Color
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int A { get; }

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

        public static Color operator +(Color c1, Color c2) =>
            new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);

        public static Color operator +(Color c1, int n) =>
            new Color(c1.R + n, c1.G + n, c1.B + n, c1.A + n);

        public static Color operator -(Color c1, Color c2) =>
            new Color(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B, c1.A - c2.A);

        public static Color operator -(Color c1, int n) =>
            new Color(c1.R - n, c1.G - n, c1.B - n, c1.A - n);

        public static Color operator *(Color c1, int n) =>
            new Color(c1.R * n, c1.G * n, c1.B * n, c1.A * n);

        public static Color operator /(Color c1, int n) =>
            new Color(c1.R / n, c1.G / n, c1.B / n, c1.A / n);

        public Color Add(Color color) => this + color;
        public Color Add(int n) => this + n;

        public Color Subtract(Color color) => this - color;
        public Color Subtract(int n) => this - n;

        public Color Multiply(int n) => this * n;
        public Color Divide(int n) => this / n;

        public (float r, float g, float b, float a) ToNormalized() =>
            (R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f);

        private static int Mod(int x, int m) => (x % m + m) % m;

        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);
        public static readonly Color Yellow = new Color(255, 255, 0);
        public static readonly Color Magenta = new Color(255, 0, 255);
        public static readonly Color Cyan = new Color(0, 255, 255);
        public static readonly Color Transparent = new Color(0, 0, 0, 0);
    }
}
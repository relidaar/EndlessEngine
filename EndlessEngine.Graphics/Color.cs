// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="Color.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Graphics
{
    /// <summary>
    /// Struct Color
    /// Implements the <see cref="System.IEquatable{EndlessEngine.Graphics.Color}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{EndlessEngine.Graphics.Color}" />
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Gets the RGBA values.
        /// </summary>
        /// <value>The RGBA values.</value>
        public (int r, int g, int b, int a) Values => (R, G, B, A);
        
        /// <summary>
        /// Gets the RGBA values as array.
        /// </summary>
        /// <value>The values array.</value>
        public int[] ValuesArray => new[] {R, G, B, A};
        
        /// <summary>
        /// Gets the R value.
        /// </summary>
        /// <value>The R value.</value>
        public int R { get; }
        
        /// <summary>
        /// Gets the G value.
        /// </summary>
        /// <value>The G value.</value>
        public int G { get; }
        
        /// <summary>
        /// Gets the B value.
        /// </summary>
        /// <value>The B value.</value>
        public int B { get; }
        
        /// <summary>
        /// Gets the A value.
        /// </summary>
        /// <value>The A value.</value>
        public int A { get; }

        #region Predefined Values

        /// <summary>
        /// The black
        /// </summary>
        public static readonly Color Black = new Color(0, 0, 0);
        /// <summary>
        /// The white
        /// </summary>
        public static readonly Color White = new Color(255, 255, 255);
        /// <summary>
        /// The red
        /// </summary>
        public static readonly Color Red = new Color(255, 0, 0);
        /// <summary>
        /// The green
        /// </summary>
        public static readonly Color Green = new Color(0, 255, 0);
        /// <summary>
        /// The blue
        /// </summary>
        public static readonly Color Blue = new Color(0, 0, 255);
        /// <summary>
        /// The yellow
        /// </summary>
        public static readonly Color Yellow = new Color(255, 255, 0);
        /// <summary>
        /// The magenta
        /// </summary>
        public static readonly Color Magenta = new Color(255, 0, 255);
        /// <summary>
        /// The cyan
        /// </summary>
        public static readonly Color Cyan = new Color(0, 255, 255);
        /// <summary>
        /// The transparent
        /// </summary>
        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="r">The R value.</param>
        /// <param name="g">The G value.</param>
        /// <param name="b">The B value.</param>
        /// <param name="a">The A value.</param>
        public Color(int r, int g, int b, int a = 255)
        {
            R = Mod(r, 256);
            G = Mod(g, 256);
            B = Mod(b, 256);
            A = Mod(a, 256);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="n">The number.</param>
        public Color(int n)
            : this(n, n, n, n)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="color">The color.</param>
        public Color(in Color color)
            : this(color.R, color.G, color.B, color.A)
        {
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Add(in Color left, in Color right)
        {
            return left + right;
        }

        /// <summary>
        /// Adds the number to the all color values.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The number.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Add(in Color left, int right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Subtract(in Color left, in Color right)
        {
            return left - right;
        }

        /// <summary>
        /// Subtracts the number from the all color values.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The numbers.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Subtract(in Color left, int right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiplies two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Multiply(in Color left, in Color right)
        {
            return left * right;
        }

        /// <summary>
        /// Multiplies the all color values by the number.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The number.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Multiply(in Color left, int right)
        {
            return left * right;
        }

        /// <summary>
        /// Divides two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Divide(in Color left, in Color right)
        {
            return left / right;
        }

        /// <summary>
        /// Divides the all color values by the number.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The number.</param>
        /// <returns>Color as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Divide(in Color left, int right)
        {
            return left / right;
        }

        /// <summary>
        /// Converts to normalized.
        /// </summary>
        /// <returns>System.ValueTuple&lt;System.Single, System.Single, System.Single, System.Single&gt;.</returns>
        public (float r, float g, float b, float a) ToNormalized()
        {
            return (R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f);
        }

        /// <summary>
        /// Normalizes the specified values.
        /// </summary>
        /// <param name="r">The R value.</param>
        /// <param name="g">The G value.</param>
        /// <param name="b">The B value.</param>
        /// <param name="a">The A value.</param>
        /// <returns>System.ValueTuple&lt;System.Single, System.Single, System.Single, System.Single&gt;.</returns>
        public static (float r, float g, float b, float a) Normalize(int r, int g, int b, int a)
        {
            return (r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
        }

        /// <summary>
        /// Get the mod of the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="m">The m.</param>
        /// <returns>System.Int32.</returns>
        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the + operator.
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Implements the + operator.
        /// Adds the number to the all color values.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The number.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Implements the - operator.
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Implements the - operator.
        /// Subtracts the number from the all color values.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The numbers.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Implements the * operator.
        /// Multiplies two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Implements the * operator.
        /// Multiplies the all color values by the number.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The number.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Implements the / operator.
        /// Divides two colors.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Divides the all color values by the number.
        /// </summary>
        /// <param name="left">The color.</param>
        /// <param name="right">The number.</param>
        /// <returns>Color as result.</returns>
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

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Color other)
        {
            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left color.</param>
        /// <param name="right">The right color.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Color left, Color right)
        {
            return !left.Equals(right);
        }
        
        #endregion
    }
}
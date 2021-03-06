// ***********************************************************************
// Assembly         : EndlessEngine.Math
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 04-13-2020
// ***********************************************************************
// <copyright file="Vector2.cs" company="EndlessEngine.Math">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    /// <summary>
    /// Struct Vector2
    /// Implements the <see cref="System.IEquatable{EndlessEngine.Math.Vector2}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{EndlessEngine.Math.Vector2}" />
    public struct Vector2 : IEquatable<Vector2>
    {
        /// <summary>
        /// Gets the size of vector.
        /// </summary>
        /// <value>The size.</value>
        public static int Size => 2;

        /// <summary>
        /// The first element.
        /// </summary>
        public float X;
        /// <summary>
        /// The second element.
        /// </summary>
        public float Y;

        /// <summary>
        /// Gets the all vector elements as IEnumerable.
        /// </summary>
        /// <value>The data.</value>
        public IEnumerable<float> Data => new[] {X, Y};

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> struct.
        /// </summary>
        /// <param name="x">The first element.</param>
        /// <param name="y">The second element.</param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> struct.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public Vector2(in Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Add(in Vector2 left, in Vector2 right)
        {
            return left + right;
        }

        /// <summary>
        /// Adds the number to the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Add(in Vector2 left, float right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Subtract(in Vector2 left, in Vector2 right)
        {
            return left - right;
        }

        /// <summary>
        /// Subtracts the number from the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Subtract(in Vector2 left, float right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiplies two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Multiply(in Vector2 left, in Vector2 right)
        {
            return left * right;
        }

        /// <summary>
        /// Multiplies the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Multiply(in Vector2 left, float right)
        {
            return left * right;
        }

        /// <summary>
        /// Divides two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Divide(in Vector2 left, in Vector2 right)
        {
            return left / right;
        }

        /// <summary>
        /// Divides the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Divide(in Vector2 left, float right)
        {
            return left / right;
        }

        /// <summary>
        /// Negates the all vector elements.
        /// </summary>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 Negate()
        {
            return new Vector2(-X, -Y);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the + operator.
        /// Adds two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X + right.X,
                left.Y + right.Y
            );
        }

        /// <summary>
        /// Implements the + operator.
        /// Adds the number to the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(in Vector2 left, float right)
        {
            return new Vector2(
                left.X + right,
                left.Y + right
            );
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X - right.X,
                left.Y - right.Y
            );
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts the number from the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(in Vector2 left, float right)
        {
            return new Vector2(
                left.X - right,
                left.Y - right
            );
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X * right.X,
                left.Y * right.Y
            );
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(in Vector2 left, float right)
        {
            return new Vector2(
                left.X * right,
                left.Y * right
            );
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X / right.X,
                left.Y / right.Y
            );
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, float right)
        {
            return new Vector2(
                left.X / right,
                left.Y / right
            );
        }

        #endregion

        #region IEquatable Implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
// ***********************************************************************
// Assembly         : EndlessEngine.Math
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="Vector4.cs" company="EndlessEngine.Math">
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
    /// Struct Vector4
    /// Implements the <see cref="System.IEquatable{EndlessEngine.Math.Vector4}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{EndlessEngine.Math.Vector4}" />
    public struct Vector4 : IEquatable<Vector4>
    {
        /// <summary>
        /// Gets the size of vector.
        /// </summary>
        /// <value>The size.</value>
        public static int Size => 4;

        /// <summary>
        /// The first element.
        /// </summary>
        public float X;
        /// <summary>
        /// The second element.
        /// </summary>
        public float Y;
        /// <summary>
        /// The third element.
        /// </summary>
        public float Z;
        /// <summary>
        /// The fourth element.
        /// </summary>
        public float W;

        /// <summary>
        /// Gets the all vector elements as IEnumerable.
        /// </summary>
        /// <value>The data.</value>
        public IEnumerable<float> Data => new[] {X, Y, Z, W};

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="x">The first element.</param>
        /// <param name="y">The second element.</param>
        /// <param name="z">The third element.</param>
        /// <param name="w">The fourth element.</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public Vector4(in Vector4 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
            W = vector.W;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Add(in Vector4 left, in Vector4 right)
        {
            return left + right;
        }

        /// <summary>
        /// Adds the number to the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Add(in Vector4 left, float right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Subtract(in Vector4 left, in Vector4 right)
        {
            return left - right;
        }

        /// <summary>
        /// Subtracts the number from the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Subtract(in Vector4 left, float right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiplies two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Multiply(in Vector4 left, in Vector4 right)
        {
            return left * right;
        }

        /// <summary>
        /// Multiplies the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Multiply(in Vector4 left, float right)
        {
            return left * right;
        }

        /// <summary>
        /// Divides two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Divide(in Vector4 left, in Vector4 right)
        {
            return left / right;
        }

        /// <summary>
        /// Divides the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Divide(in Vector4 left, float right)
        {
            return left / right;
        }

        /// <summary>
        /// Negates this instance.
        /// </summary>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 Negate()
        {
            return new Vector4(-X, -Y, -Z, -W);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the + operator.
        /// Adds two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator +(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z,
                left.W + right.W
            );
        }

        /// <summary>
        /// Implements the + operator.
        /// Adds the number to the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator +(in Vector4 left, float right)
        {
            return new Vector4(
                left.X + right,
                left.Y + right,
                left.Z + right,
                left.W + right
            );
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z,
                left.W - right.W
            );
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts the number from the all vector elements.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, float right)
        {
            return new Vector4(
                left.X - right,
                left.Y - right,
                left.Z - right,
                left.W - right
            );
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X * right.X,
                left.Y * right.Y,
                left.Z * right.Z,
                left.W * right.W
            );
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, float right)
        {
            return new Vector4(
                left.X * right,
                left.Y * right,
                left.Z * right,
                left.W * right
            );
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides two vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X / right.X,
                left.Y / right.Y,
                left.Z / right.Z,
                left.W / right.W
            );
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides the all vector elements by the number.
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The number.</param>
        /// <returns>Vector4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, float right)
        {
            return new Vector4(
                left.X / right,
                left.Y / right,
                left.Z / right,
                left.W / right
            );
        }

        #endregion

        #region IEquatable Implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Vector4 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4 left, Vector4 right)
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
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
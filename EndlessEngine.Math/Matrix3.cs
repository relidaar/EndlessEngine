// ***********************************************************************
// Assembly         : EndlessEngine.Math
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="Matrix3.cs" company="EndlessEngine.Math">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    /// <summary>
    /// Struct Matrix3
    /// Implements the <see cref="System.IEquatable{EndlessEngine.Math.Matrix3}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{EndlessEngine.Math.Matrix3}" />
    public struct Matrix3 : IEquatable<Matrix3>
    {
        /// <summary>
        /// Gets the size of matrix.
        /// </summary>
        /// <value>The size.</value>
        public static (int m, int n) Size => (3, 3);

        #region Public Fields

        // First row
        
        /// <summary>
        /// The element 11
        /// </summary>
        public float M11;
        /// <summary>
        /// The element 12
        /// </summary>
        public float M12;
        /// <summary>
        /// The element 13
        /// </summary>
        public float M13;

        // Second row
        
        /// <summary>
        /// The element 21
        /// </summary>
        public float M21;
        /// <summary>
        /// The element 22
        /// </summary>
        public float M22;
        /// <summary>
        /// The element 23
        /// </summary>
        public float M23;

        // Third row
        
        /// <summary>
        /// The element 31
        /// </summary>
        public float M31;
        /// <summary>
        /// The element 32
        /// </summary>
        public float M32;
        /// <summary>
        /// The element 33
        /// </summary>
        public float M33;

        #endregion

        /// <summary>
        /// Gets the matrix as two-dimensional array.
        /// </summary>
        /// <value>The matrix.</value>
        public float[,] Matrix => new[,]
        {
            {M11, M12, M13},
            {M21, M22, M23},
            {M31, M32, M33}
        };

        /// <summary>
        /// Gets the matrix as array.
        /// </summary>
        /// <value>The array.</value>
        public float[] Array => new[]
        {
            M11, M12, M13,
            M21, M22, M23,
            M31, M32, M33
        };

        /// <summary>
        /// Gets the identity matrix.
        /// </summary>
        /// <value>The identity.</value>
        public static Matrix3 Identity =>
            new Matrix3
            (
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            );

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Matrix3(float value)
        {
            // First row
            M11 = value;
            M12 = value;
            M13 = value;

            // Second row
            M21 = value;
            M22 = value;
            M23 = value;

            // Third row
            M31 = value;
            M32 = value;
            M33 = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public Matrix3(in Matrix3 matrix)
        {
            // First row
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;

            // Second row
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;

            // Third row
            M31 = matrix.M31;
            M32 = matrix.M32;
            M33 = matrix.M33;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> struct.
        /// </summary>
        /// <param name="m11">The element 11.</param>
        /// <param name="m12">The element 12.</param>
        /// <param name="m13">The element 13.</param>
        /// <param name="m21">The element 21.</param>
        /// <param name="m22">The element 22.</param>
        /// <param name="m23">The element 23.</param>
        /// <param name="m31">The element 31.</param>
        /// <param name="m32">The element 32.</param>
        /// <param name="m33">The element 33.</param>
        public Matrix3(
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            // First row
            M11 = m11;
            M12 = m12;
            M13 = m13;

            // Second row
            M21 = m21;
            M22 = m22;
            M23 = m23;

            // Third row
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Add(in Matrix3 left, in Matrix3 right)
        {
            return left + right;
        }

        /// <summary>
        /// Adds the number to the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Add(in Matrix3 left, float right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Subtract(in Matrix3 left, in Matrix3 right)
        {
            return left - right;
        }

        /// <summary>
        /// Subtracts the number from the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Subtract(in Matrix3 left, float right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Multiply(in Matrix3 left, in Matrix3 right)
        {
            return left * right;
        }

        /// <summary>
        /// Multiplies the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Multiply(in Matrix3 left, float right)
        {
            return left * right;
        }

        /// <summary>
        /// Divides two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 Divide(in Matrix3 left, float right)
        {
            return left / right;
        }

        /// <summary>
        /// Transposes this matrix instance.
        /// </summary>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix3 Transpose()
        {
            Matrix3 result;

            // First row
            result.M11 = M11;
            result.M12 = M21;
            result.M13 = M31;

            // Second row
            result.M21 = M12;
            result.M22 = M22;
            result.M23 = M32;

            // Third row
            result.M31 = M13;
            result.M32 = M23;
            result.M33 = M33;

            return result;
        }

        /// <summary>
        /// Negates the all matrix elements.
        /// </summary>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix3 Negate()
        {
            return new Matrix3(
                -M11, -M12, -M13,
                -M21, -M22, -M23,
                -M31, -M32, -M33
            );
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the + operator.
        /// Adds two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator +(in Matrix3 left, in Matrix3 right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 + right.M11,
                M12 = left.M12 + right.M12,
                M13 = left.M13 + right.M13,

                // Second row
                M21 = left.M21 + right.M21,
                M22 = left.M22 + right.M22,
                M23 = left.M23 + right.M23,

                // Third row
                M31 = left.M31 + right.M31,
                M32 = left.M32 + right.M32,
                M33 = left.M33 + right.M33
            };
        }

        /// <summary>
        /// Implements the + operator.
        /// Adds the number to the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator +(in Matrix3 left, float right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 + right,
                M12 = left.M12 + right,
                M13 = left.M13 + right,

                // Second row
                M21 = left.M21 + right,
                M22 = left.M22 + right,
                M23 = left.M23 + right,

                // Third row
                M31 = left.M31 + right,
                M32 = left.M32 + right,
                M33 = left.M33 + right
            };
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator -(in Matrix3 left, in Matrix3 right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 - right.M11,
                M12 = left.M12 - right.M12,
                M13 = left.M13 - right.M13,

                // Second row
                M21 = left.M21 - right.M21,
                M22 = left.M22 - right.M22,
                M23 = left.M23 - right.M23,

                // Third row
                M31 = left.M31 - right.M31,
                M32 = left.M32 - right.M32,
                M33 = left.M33 - right.M33
            };
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts the number from the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator -(in Matrix3 left, float right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 - right,
                M12 = left.M12 - right,
                M13 = left.M13 - right,

                // Second row
                M21 = left.M21 - right,
                M22 = left.M22 - right,
                M23 = left.M23 - right,

                // Third row
                M31 = left.M31 - right,
                M32 = left.M32 - right,
                M33 = left.M33 - right
            };
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator *(in Matrix3 left, in Matrix3 right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31,
                M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32,
                M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33,

                // Second row
                M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31,
                M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32,
                M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33,

                // Third row
                M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31,
                M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32,
                M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33
            };
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator *(in Matrix3 left, float right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 * right,
                M12 = left.M12 * right,
                M13 = left.M13 * right,

                // Second row
                M21 = left.M21 * right,
                M22 = left.M22 * right,
                M23 = left.M23 * right,

                // Third row
                M31 = left.M31 * right,
                M32 = left.M32 * right,
                M33 = left.M33 * right
            };
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix3 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3 operator /(in Matrix3 left, float right)
        {
            return new Matrix3
            {
                // First row
                M11 = left.M11 / right,
                M12 = left.M12 / right,
                M13 = left.M13 / right,

                // Second row
                M21 = left.M21 / right,
                M22 = left.M22 / right,
                M23 = left.M23 / right,

                // Third row
                M31 = left.M31 / right,
                M32 = left.M32 / right,
                M33 = left.M33 / right
            };
        }

        #endregion

        #region IEquatable Implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Matrix3 other)
        {
            return M11.Equals(other.M11) && M12.Equals(other.M12) && M13.Equals(other.M13) && M21.Equals(other.M21) &&
                   M22.Equals(other.M22) && M23.Equals(other.M23) && M31.Equals(other.M31) && M32.Equals(other.M32) &&
                   M33.Equals(other.M33);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix3 left, Matrix3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
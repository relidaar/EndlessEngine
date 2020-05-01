// ***********************************************************************
// Assembly         : EndlessEngine.Math
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="The Matrix2 as result.cs" company="EndlessEngine.Math">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    /// <summary>
    /// Struct Matrix2
    /// Implements the <see cref="System.IEquatable{EndlessEngine.Math.Matrix2}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{EndlessEngine.Math.Matrix2}" />
    public struct Matrix2 : IEquatable<Matrix2>
    {
        /// <summary>
        /// Gets the size of matrix.
        /// </summary>
        /// <value>The size.</value>
        public static (int m, int n) Size => (2, 2);

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

        // Second row
        
        /// <summary>
        /// The element 21
        /// </summary>
        public float M21;
        /// <summary>
        /// The element 22
        /// </summary>
        public float M22;

        #endregion

        /// <summary>
        /// Gets the matrix as two-dimensional array.
        /// </summary>
        /// <value>The matrix.</value>
        public float[,] Matrix => new[,]
        {
            {M11, M12},
            {M21, M22}
        };

        /// <summary>
        /// Gets the matrix as array.
        /// </summary>
        /// <value>The array.</value>
        public float[] Array => new[]
        {
            M11, M12,
            M21, M22
        };

        /// <summary>
        /// Gets the identity matrix.
        /// </summary>
        /// <value>The identity.</value>
        public static Matrix2 Identity =>
            new Matrix2
            (
                1, 0,
                0, 1
            );

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Matrix2(float value)
        {
            // First row
            M11 = value;
            M12 = value;

            // Second row
            M21 = value;
            M22 = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2"/> struct.
        /// </summary>
        /// <param name="m11">The element 11.</param>
        /// <param name="m12">The element 12.</param>
        /// <param name="m21">The element 21.</param>
        /// <param name="m22">The element 22.</param>
        public Matrix2(
            float m11, float m12,
            float m21, float m22)
        {
            // First row
            M11 = m11;
            M12 = m12;

            // Second row
            M21 = m21;
            M22 = m22;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public Matrix2(in Matrix2 matrix)
        {
            // First row
            M11 = matrix.M11;
            M12 = matrix.M12;

            // Second row
            M21 = matrix.M21;
            M22 = matrix.M22;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Add(in Matrix2 left, in Matrix2 right)
        {
            return left + right;
        }

        /// <summary>
        /// Adds the number to the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Add(in Matrix2 left, float right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Subtract(in Matrix2 left, in Matrix2 right)
        {
            return left - right;
        }

        /// <summary>
        /// Subtracts the number from the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Subtract(in Matrix2 left, float right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Multiply(in Matrix2 left, in Matrix2 right)
        {
            return left * right;
        }

        /// <summary>
        /// Multiplies the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Multiply(in Matrix2 left, float right)
        {
            return left * right;
        }

        /// <summary>
        /// Divides the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Divide(in Matrix2 left, float right)
        {
            return left / right;
        }

        /// <summary>
        /// Transposes this matrix instance.
        /// </summary>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix2 Transpose()
        {
            Matrix2 result;

            // First row
            result.M11 = M11;
            result.M12 = M21;

            // Second row
            result.M21 = M12;
            result.M22 = M22;

            return result;
        }

        /// <summary>
        /// Negates the all matrix elements.
        /// </summary>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix2 Negate()
        {
            return new Matrix2(
                -M11, -M12, 
                -M21, -M22
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
        /// <returns>Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator +(in Matrix2 left, in Matrix2 right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 + right.M11,
                M12 = left.M12 + right.M12,

                // Second row
                M21 = left.M21 + right.M21,
                M22 = left.M22 + right.M22
            };
        }

        /// <summary>
        /// Implements the + operator.
        /// Adds the number to the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator +(in Matrix2 left, float right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 + right,
                M12 = left.M12 + right,

                // Second row
                M21 = left.M21 + right,
                M22 = left.M22 + right
            };
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator -(in Matrix2 left, in Matrix2 right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 - right.M11,
                M12 = left.M12 - right.M12,

                // Second row
                M21 = left.M21 - right.M21,
                M22 = left.M22 - right.M22
            };
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts the number from the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator -(in Matrix2 left, float right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 - right,
                M12 = left.M12 - right,

                // Second row
                M21 = left.M21 - right,
                M22 = left.M22 - right
            };
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator *(in Matrix2 left, in Matrix2 right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 * right.M11 + left.M12 * right.M21,
                M12 = left.M11 * right.M12 + left.M12 * right.M22,

                // Second row
                M21 = left.M21 * right.M11 + left.M22 * right.M21,
                M22 = left.M21 * right.M12 + left.M22 * right.M22
            };
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator *(in Matrix2 left, float right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 * right,
                M12 = left.M12 * right,

                // Second row
                M21 = left.M21 * right,
                M22 = left.M22 * right
            };
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix2 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator /(in Matrix2 left, float right)
        {
            return new Matrix2
            {
                // First row
                M11 = left.M11 / right,
                M12 = left.M12 / right,

                // Second row
                M21 = left.M21 / right,
                M22 = left.M22 / right
            };
        }

        #endregion

        #region IEquatable Implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Matrix2 other)
        {
            return M11.Equals(other.M11) && M12.Equals(other.M12) && M21.Equals(other.M21) && M22.Equals(other.M22);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix2 left, Matrix2 right)
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
        public static bool operator !=(Matrix2 left, Matrix2 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
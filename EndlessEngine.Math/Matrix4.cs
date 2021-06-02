// ***********************************************************************
// Assembly         : EndlessEngine.Math
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="Matrix4 as result.cs" company="EndlessEngine.Math">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    /// <summary>
    /// Struct Matrix4
    /// Implements the <see cref="System.IEquatable{EndlessEngine.Math.Matrix4}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{EndlessEngine.Math.Matrix4}" />
    public struct Matrix4 : IEquatable<Matrix4>
    {
        /// <summary>
        /// Gets the size of matrix.
        /// </summary>
        /// <value>The size.</value>
        public static (int m, int n) Size => (4, 4);

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
        /// <summary>
        /// The element 14
        /// </summary>
        public float M14;

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
        /// <summary>
        /// The element 24
        /// </summary>
        public float M24;

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
        /// <summary>
        /// The element 34
        /// </summary>
        public float M34;

        // Fourth row
        
        /// <summary>
        /// The element 41
        /// </summary>
        public float M41;
        /// <summary>
        /// The element 42
        /// </summary>
        public float M42;
        /// <summary>
        /// The element 43
        /// </summary>
        public float M43;
        /// <summary>
        /// The element 44
        /// </summary>
        public float M44;

        #endregion

        /// <summary>
        /// Gets the matrix as two-dimensional array.
        /// </summary>
        /// <value>The matrix.</value>
        public float[,] Matrix => new[,]
        {
            {M11, M12, M13, M14},
            {M21, M22, M23, M24},
            {M31, M32, M33, M34},
            {M41, M42, M43, M44}
        };

        /// <summary>
        /// Gets the matrix as array.
        /// </summary>
        /// <value>The array.</value>
        public float[] Array => new[]
        {
            M11, M12, M13, M14,
            M21, M22, M23, M24,
            M31, M32, M33, M34,
            M41, M42, M43, M44
        };

        /// <summary>
        /// Gets the identity matrix.
        /// </summary>
        /// <value>The identity.</value>
        public static Matrix4 Identity =>
            new Matrix4
            {
                M11 = 1,
                M22 = 1,
                M33 = 1,
                M44 = 1
            };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public Matrix4(in Matrix4 matrix)
        {
            // First row
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;
            M14 = matrix.M14;

            // Second row
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;
            M24 = matrix.M24;

            // Third row
            M31 = matrix.M31;
            M32 = matrix.M32;
            M33 = matrix.M33;
            M34 = matrix.M34;

            // Fourth row
            M41 = matrix.M41;
            M42 = matrix.M42;
            M43 = matrix.M43;
            M44 = matrix.M44;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Matrix4(float value)
        {
            // First row
            M11 = value;
            M12 = value;
            M13 = value;
            M14 = value;

            // Second row
            M21 = value;
            M22 = value;
            M23 = value;
            M24 = value;

            // Third row
            M31 = value;
            M32 = value;
            M33 = value;
            M34 = value;

            // Fourth row
            M41 = value;
            M42 = value;
            M43 = value;
            M44 = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4"/> struct.
        /// </summary>
        /// <param name="m11">The element 11.</param>
        /// <param name="m12">The element 12.</param>
        /// <param name="m13">The element 13.</param>
        /// <param name="m14">The element 14.</param>
        /// <param name="m21">The element 21.</param>
        /// <param name="m22">The element 22.</param>
        /// <param name="m23">The element 23.</param>
        /// <param name="m24">The element 24.</param>
        /// <param name="m31">The element 31.</param>
        /// <param name="m32">The element 32.</param>
        /// <param name="m33">The element 33.</param>
        /// <param name="m34">The element 34.</param>
        /// <param name="m41">The element 41.</param>
        /// <param name="m42">The element 42.</param>
        /// <param name="m43">The element 43.</param>
        /// <param name="m44">The element 44.</param>
        public Matrix4(
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            // First row
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;

            // Second row
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;

            // Third row
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;

            // Fourth row
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Add(in Matrix4 left, in Matrix4 right)
        {
            return left + right;
        }

        /// <summary>
        /// Adds the number to the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Add(in Matrix4 left, float right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Subtract(in Matrix4 left, in Matrix4 right)
        {
            return left - right;
        }

        /// <summary>
        /// Subtracts the number from the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Subtract(in Matrix4 left, float right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Multiply(in Matrix4 left, in Matrix4 right)
        {
            return left * right;
        }

        /// <summary>
        /// Multiplies the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Multiply(in Matrix4 left, float right)
        {
            return left * right;
        }

        /// <summary>
        /// Divides the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Divide(in Matrix4 left, float right)
        {
            return left / right;
        }

        /// <summary>
        /// Transposes this matrix instance.
        /// </summary>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4 Transpose()
        {
            Matrix4 result;

            // First row
            result.M11 = M11;
            result.M12 = M21;
            result.M13 = M31;
            result.M14 = M41;

            // Second row
            result.M21 = M12;
            result.M22 = M22;
            result.M23 = M32;
            result.M24 = M42;

            // Third row
            result.M31 = M13;
            result.M32 = M23;
            result.M33 = M33;
            result.M34 = M43;

            // Fourth row
            result.M41 = M14;
            result.M42 = M24;
            result.M43 = M34;
            result.M44 = M44;

            return result;
        }

        /// <summary>
        /// Inverts this matrix instance.
        /// </summary>
        /// <returns>Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4 Invert()
        {
            var inverse = new float[16];

            inverse[0] = M22 * M33 * M44 -
                         M22 * M34 * M43 -
                         M32 * M23 * M44 +
                         M32 * M24 * M43 +
                         M42 * M23 * M34 -
                         M42 * M24 * M33;

            inverse[4] = -M21 * M33 * M44 +
                         M21 * M34 * M43 +
                         M31 * M23 * M44 -
                         M31 * M24 * M43 -
                         M41 * M23 * M34 +
                         M41 * M24 * M33;

            inverse[8] = M21 * M32 * M44 -
                         M21 * M34 * M42 -
                         M31 * M22 * M44 +
                         M31 * M24 * M42 +
                         M41 * M22 * M34 -
                         M41 * M24 * M32;

            inverse[12] = -M21 * M32 * M43 +
                          M21 * M33 * M42 +
                          M31 * M22 * M43 -
                          M31 * M23 * M42 -
                          M41 * M22 * M33 +
                          M41 * M23 * M32;

            inverse[1] = -M12 * M33 * M44 +
                         M12 * M34 * M43 +
                         M32 * M13 * M44 -
                         M32 * M14 * M43 -
                         M42 * M13 * M34 +
                         M42 * M14 * M33;

            inverse[5] = M11 * M33 * M44 -
                         M11 * M34 * M43 -
                         M31 * M13 * M44 +
                         M31 * M14 * M43 +
                         M41 * M13 * M34 -
                         M41 * M14 * M33;

            inverse[9] = -M11 * M32 * M44 +
                         M11 * M34 * M42 +
                         M31 * M12 * M44 -
                         M31 * M14 * M42 -
                         M41 * M12 * M34 +
                         M41 * M14 * M32;

            inverse[13] = M11 * M32 * M43 -
                          M11 * M33 * M42 -
                          M31 * M12 * M43 +
                          M31 * M13 * M42 +
                          M41 * M12 * M33 -
                          M41 * M13 * M32;

            inverse[2] = M12 * M23 * M44 -
                         M12 * M24 * M43 -
                         M22 * M13 * M44 +
                         M22 * M14 * M43 +
                         M42 * M13 * M24 -
                         M42 * M14 * M23;

            inverse[6] = -M11 * M23 * M44 +
                         M11 * M24 * M43 +
                         M21 * M13 * M44 -
                         M21 * M14 * M43 -
                         M41 * M13 * M24 +
                         M41 * M14 * M23;

            inverse[10] = M11 * M22 * M44 -
                          M11 * M24 * M42 -
                          M21 * M12 * M44 +
                          M21 * M14 * M42 +
                          M41 * M12 * M24 -
                          M41 * M14 * M22;

            inverse[14] = -M11 * M22 * M43 +
                          M11 * M23 * M42 +
                          M21 * M12 * M43 -
                          M21 * M13 * M42 -
                          M41 * M12 * M23 +
                          M41 * M13 * M22;

            inverse[3] = -M12 * M23 * M34 +
                         M12 * M24 * M33 +
                         M22 * M13 * M34 -
                         M22 * M14 * M33 -
                         M32 * M13 * M24 +
                         M32 * M14 * M23;

            inverse[7] = M11 * M23 * M34 -
                         M11 * M24 * M33 -
                         M21 * M13 * M34 +
                         M21 * M14 * M33 +
                         M31 * M13 * M24 -
                         M31 * M14 * M23;

            inverse[11] = -M11 * M22 * M34 +
                          M11 * M24 * M32 +
                          M21 * M12 * M34 -
                          M21 * M14 * M32 -
                          M31 * M12 * M24 +
                          M31 * M14 * M22;

            inverse[15] = M11 * M22 * M33 -
                          M11 * M23 * M32 -
                          M21 * M12 * M33 +
                          M21 * M13 * M32 +
                          M31 * M12 * M23 -
                          M31 * M13 * M22;

            var det = M11 * inverse[0] + M12 * inverse[4] + M13 * inverse[8] + M14 * inverse[12];

            if (det == 0)
                return new Matrix4(0);

            det = 1 / System.Math.Abs(det);

            for (var i = 0; i < 16; i++)
                inverse[i] = inverse[i] * det;

            return new Matrix4
            {
                // First row
                M11 = inverse[0],
                M12 = inverse[1],
                M13 = inverse[2],
                M14 = inverse[3],

                // Second row
                M21 = inverse[4],
                M22 = inverse[5],
                M23 = inverse[6],
                M24 = inverse[7],

                // Third row
                M31 = inverse[8],
                M32 = inverse[9],
                M33 = inverse[10],
                M34 = inverse[11],

                // Fourth row
                M41 = inverse[12],
                M42 = inverse[13],
                M43 = inverse[14],
                M44 = inverse[15]
            };
        }

        /// <summary>
        /// Negates the all matrix elements.
        /// </summary>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4 Negate()
        {
            return new Matrix4(
                -M11, -M12, -M13, -M14,
                -M21, -M22, -M23, -M24,
                -M31, -M32, -M33, -M34,
                -M41, -M42, -M43, -M44
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
        /// <returns>Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator +(in Matrix4 left, in Matrix4 right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 + right.M11,
                M12 = left.M12 + right.M12,
                M13 = left.M13 + right.M13,
                M14 = left.M14 + right.M14,

                // Second row
                M21 = left.M21 + right.M21,
                M22 = left.M22 + right.M22,
                M23 = left.M23 + right.M23,
                M24 = left.M24 + right.M24,

                // Third row
                M31 = left.M31 + right.M31,
                M32 = left.M32 + right.M32,
                M33 = left.M33 + right.M33,
                M34 = left.M34 + right.M34,

                // Fourth row
                M41 = left.M41 + right.M41,
                M42 = left.M42 + right.M42,
                M43 = left.M43 + right.M43,
                M44 = left.M44 + right.M44
            };
        }

        /// <summary>
        /// Implements the + operator.
        /// Adds the number to the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator +(in Matrix4 left, float right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 + right,
                M12 = left.M12 + right,
                M13 = left.M13 + right,
                M14 = left.M14 + right,

                // Second row
                M21 = left.M21 + right,
                M22 = left.M22 + right,
                M23 = left.M23 + right,
                M24 = left.M24 + right,

                // Third row
                M31 = left.M31 + right,
                M32 = left.M32 + right,
                M33 = left.M33 + right,
                M34 = left.M34 + right,

                // Fourth row
                M41 = left.M41 + right,
                M42 = left.M42 + right,
                M43 = left.M43 + right,
                M44 = left.M44 + right
            };
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator -(in Matrix4 left, in Matrix4 right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 - right.M11,
                M12 = left.M12 - right.M12,
                M13 = left.M13 - right.M13,
                M14 = left.M14 - right.M14,

                // Second row
                M21 = left.M21 - right.M21,
                M22 = left.M22 - right.M22,
                M23 = left.M23 - right.M23,
                M24 = left.M24 - right.M24,

                // Third row
                M31 = left.M31 - right.M31,
                M32 = left.M32 - right.M32,
                M33 = left.M33 - right.M33,
                M34 = left.M34 - right.M34,

                // Fourth row
                M41 = left.M41 - right.M41,
                M42 = left.M42 - right.M42,
                M43 = left.M43 - right.M43,
                M44 = left.M44 - right.M44
            };
        }

        /// <summary>
        /// Implements the - operator.
        /// Subtracts the number from the all matrix elements.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator -(in Matrix4 left, float right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 - right,
                M12 = left.M12 - right,
                M13 = left.M13 - right,
                M14 = left.M14 - right,

                // Second row
                M21 = left.M21 - right,
                M22 = left.M22 - right,
                M23 = left.M23 - right,
                M24 = left.M24 - right,

                // Third row
                M31 = left.M31 - right,
                M32 = left.M32 - right,
                M33 = left.M33 - right,
                M34 = left.M34 - right,

                // Fourth row
                M41 = left.M41 - right,
                M42 = left.M42 - right,
                M43 = left.M43 - right,
                M44 = left.M44 - right
            };
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator *(in Matrix4 left, in Matrix4 right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41,
                M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42,
                M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43,
                M14 = left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44,

                // Second row
                M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41,
                M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42,
                M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43,
                M24 = left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44,

                // Third row
                M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41,
                M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42,
                M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43,
                M34 = left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44,

                // Fourth row
                M41 = left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41,
                M42 = left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42,
                M43 = left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43,
                M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44
            };
        }

        /// <summary>
        /// Implements the * operator.
        /// Multiplies the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator *(in Matrix4 left, float right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 * right,
                M12 = left.M12 * right,
                M13 = left.M13 * right,
                M14 = left.M14 * right,

                // Second row
                M21 = left.M21 * right,
                M22 = left.M22 * right,
                M23 = left.M23 * right,
                M24 = left.M24 * right,

                // Third row
                M31 = left.M31 * right,
                M32 = left.M32 * right,
                M33 = left.M33 * right,
                M34 = left.M34 * right,

                // Fourth row
                M41 = left.M41 * right,
                M42 = left.M42 * right,
                M43 = left.M43 * right,
                M44 = left.M44 * right
            };
        }

        /// <summary>
        /// Implements the / operator.
        /// Divides the all matrix elements by the number.
        /// </summary>
        /// <param name="left">The matrix.</param>
        /// <param name="right">The number.</param>
        /// <returns>The Matrix4 as result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 operator /(in Matrix4 left, float right)
        {
            return new Matrix4
            {
                // First row
                M11 = left.M11 / right,
                M12 = left.M12 / right,
                M13 = left.M13 / right,
                M14 = left.M14 / right,

                // Second row
                M21 = left.M21 / right,
                M22 = left.M22 / right,
                M23 = left.M23 / right,
                M24 = left.M24 / right,

                // Third row
                M31 = left.M31 / right,
                M32 = left.M32 / right,
                M33 = left.M33 / right,
                M34 = left.M34 / right,

                // Fourth row
                M41 = left.M41 / right,
                M42 = left.M42 / right,
                M43 = left.M43 / right,
                M44 = left.M44 / right
            };
        }

        #endregion

        #region Transformation Matrices

        /// <summary>
        /// Creates scaled matrix from vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Scaled(in Vector3 vector)
        {
            return Scaled(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Creates a scaled matrix from the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Scaled(in Vector2 vector)
        {
            return Scaled(vector.X, vector.Y);
        }

        /// <summary>
        /// Creates a scaled matrix from the values.
        /// </summary>
        /// <param name="x">The element 11.</param>
        /// <param name="y">The element 22.</param>
        /// <param name="z">The element 33.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Scaled(float x, float y, float z = 1)
        {
            var result = Identity;

            result.M11 = x;
            result.M22 = y;
            result.M33 = z;

            return result;
        }

        /// <summary>
        /// Creates a translated matrix from the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Translated(in Vector3 vector)
        {
            return Translated(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Creates a translated matrix from the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Translated(in Vector2 vector)
        {
            return Translated(vector.X, vector.Y);
        }

        /// <summary>
        /// Creates a translated matrix from the values.
        /// </summary>
        /// <param name="x">The element 14.</param>
        /// <param name="y">The element 24.</param>
        /// <param name="z">The element 34.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Translated(float x, float y, float z = 0)
        {
            var result = Identity;

            result.M14 = x;
            result.M24 = y;
            result.M34 = z;

            return result;
        }

        /// <summary>
        /// Creates a rotated matrix from the angle and the vector.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="vector">The vector.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Rotated(float angle, in Vector3 vector)
        {
            return Rotated(angle, vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Creates a rotated matrix from the angle and the values.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Rotated(float angle, float x, float y, float z)
        {
            var cos = (float) System.Math.Cos(angle);
            var sin = (float) System.Math.Sin(angle);

            var result = Identity;

            // First row
            result.M11 = (float) (System.Math.Pow(x, 2) * (1 - cos) + cos);
            result.M12 = x * y * (1 - cos) - z * sin;
            result.M13 = x * z * (1 - cos) + y * sin;

            // Second row
            result.M21 = x * y * (1 - cos) + z * sin;
            result.M22 = (float) (System.Math.Pow(y, 2) * (1 - cos) + cos);
            result.M23 = y * z * (1 - cos) - x * sin;

            // Third row
            result.M31 = x * z * (1 - cos) - y * sin;
            result.M32 = y * z * (1 - cos) + x * sin;
            result.M33 = (float) (System.Math.Pow(z, 2) * (1 - cos) + cos);

            return result;
        }

        #endregion

        #region View Projection Matrices

        /// <summary>
        /// Creates an orthographic matrix.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="near">The near.</param>
        /// <param name="far">The far.</param>
        /// <returns>Matrix4 as result.</returns>
        public static Matrix4 Orthographic(float left, float right, float bottom, float top,
            float near = -1, float far = 1)
        {
            var result = Identity;

            result.M11 = 2 / (right - left);
            result.M14 = -(right + left) / (right - left);

            result.M22 = 2 / (top - bottom);
            result.M24 = -(top + bottom) / (top - bottom);

            result.M33 = -2 / (far - near);
            result.M34 = -(far + near) / (far - near);

            return result;
        }

        #endregion

        #region IEquatable Implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Matrix4 other)
        {
            return M11.Equals(other.M11) && M12.Equals(other.M12) && M13.Equals(other.M13) && M14.Equals(other.M14) &&
                   M21.Equals(other.M21) && M22.Equals(other.M22) && M23.Equals(other.M23) && M24.Equals(other.M24) &&
                   M31.Equals(other.M31) && M32.Equals(other.M32) && M33.Equals(other.M33) && M34.Equals(other.M34) &&
                   M41.Equals(other.M41) && M42.Equals(other.M42) && M43.Equals(other.M43) && M44.Equals(other.M44);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The result of the operator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix4 left, Matrix4 right)
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
        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
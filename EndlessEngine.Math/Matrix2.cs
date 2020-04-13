using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    public struct Matrix2 : IEquatable<Matrix2>
    {
        public static (int m, int n) Size => (2, 2);

        #region Public Fields

        // First row
        public float M11;
        public float M12;

        // Second row
        public float M21;
        public float M22;

        #endregion

        public float[,] Matrix => new[,]
        {
            {M11, M12},
            {M21, M22}
        };

        public float[] Array => new[]
        {
            M11, M12,
            M21, M22
        };

        public static Matrix2 Identity =>
            new Matrix2
            (
                1, 0,
                0, 1
            );

        #region Constructors

        public Matrix2(float value)
        {
            // First row
            M11 = value;
            M12 = value;

            // Second row
            M21 = value;
            M22 = value;
        }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Add(in Matrix2 left, in Matrix2 right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Add(in Matrix2 left, float right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Subtract(in Matrix2 left, in Matrix2 right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Subtract(in Matrix2 left, float right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Multiply(in Matrix2 left, in Matrix2 right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Multiply(in Matrix2 left, float right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Divide(in Matrix2 left, float right)
        {
            return left / right;
        }

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

        public bool Equals(Matrix2 other)
        {
            return M11.Equals(other.M11) && M12.Equals(other.M12) && M21.Equals(other.M21) && M22.Equals(other.M22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix2 left, Matrix2 right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix2 left, Matrix2 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
using System;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    public struct Matrix4 : IEquatable<Matrix4>
    {
        public static (int m, int n) Size => (4, 4);

        #region Public Fields

        // First row
        public float M11;
        public float M12;
        public float M13;
        public float M14;

        // Second row
        public float M21;
        public float M22;
        public float M23;
        public float M24;

        // Third row
        public float M31;
        public float M32;
        public float M33;
        public float M34;

        // Fourth row
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        #endregion

        public float[,] Matrix => new[,]
        {
            {M11, M12, M13, M14},
            {M21, M22, M23, M24},
            {M31, M32, M33, M34},
            {M41, M42, M43, M44}
        };

        public float[] Array => new[]
        {
            M11, M12, M13, M14,
            M21, M22, M23, M24,
            M31, M32, M33, M34,
            M41, M42, M43, M44
        };

        public static Matrix4 Identity =>
            new Matrix4
            {
                M11 = 1,
                M22 = 1,
                M33 = 1,
                M44 = 1
            };

        #region Constructors

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Add(in Matrix4 left, in Matrix4 right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Add(in Matrix4 left, float right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Subtract(in Matrix4 left, in Matrix4 right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Subtract(in Matrix4 left, float right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Multiply(in Matrix4 left, in Matrix4 right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Multiply(in Matrix4 left, float right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4 Divide(in Matrix4 left, float right)
        {
            return left / right;
        }

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
                M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M33 + left.M44 * right.M44
            };
        }

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

        public static Matrix4 Scaled(in Vector3 vector)
        {
            return Scaled(vector.X, vector.Y, vector.Z);
        }

        public static Matrix4 Scaled(in Vector2 vector)
        {
            return Scaled(vector.X, vector.Y);
        }

        public static Matrix4 Scaled(float x, float y, float z = 1)
        {
            var result = Identity;

            result.M11 = x;
            result.M22 = y;
            result.M33 = z;

            return result;
        }

        public static Matrix4 Translated(in Vector3 vector)
        {
            return Translated(vector.X, vector.Y, vector.Z);
        }

        public static Matrix4 Translated(in Vector2 vector)
        {
            return Translated(vector.X, vector.Y);
        }

        public static Matrix4 Translated(float x, float y, float z = 0)
        {
            var result = Identity;

            result.M14 = x;
            result.M24 = y;
            result.M34 = z;

            return result;
        }

        public static Matrix4 Rotated(float angle, in Vector3 vector)
        {
            return Rotated(angle, vector.X, vector.Y, vector.Z);
        }

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

        public static Matrix4 Orthographic(float left, float right, float bottom, float top,
            float near = -1, float far = 1)
        {
            var result = Identity;

            result.M11 = 2 / (right - left);
            result.M14 = -(right + left) / (right - left);

            result.M22 = 2 / (top - bottom);
            result.M24 = -(top + bottom) / (top - bottom);

            result.M32 = -2 / (far - near);
            result.M34 = -(far + near) / (far - near);

            return result;
        }

        #endregion

        #region IEquatable Implementation

        public bool Equals(Matrix4 other)
        {
            return M11.Equals(other.M11) && M12.Equals(other.M12) && M13.Equals(other.M13) && M14.Equals(other.M14) &&
                   M21.Equals(other.M21) && M22.Equals(other.M22) && M23.Equals(other.M23) && M24.Equals(other.M24) &&
                   M31.Equals(other.M31) && M32.Equals(other.M32) && M33.Equals(other.M33) && M34.Equals(other.M34) &&
                   M41.Equals(other.M41) && M42.Equals(other.M42) && M43.Equals(other.M43) && M44.Equals(other.M44);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix4 left, Matrix4 right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
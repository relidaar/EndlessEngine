namespace EndlessEngine.Math
{
    public struct Matrix3
    {
        public static (int m, int n) Size => (3, 3);

        #region Public Fields

        // First row
        public float M11;
        public float M12;
        public float M13;

        // Second row
        public float M21;
        public float M22;
        public float M23;

        // Third row
        public float M31;
        public float M32;
        public float M33;

        #endregion

        public float[,] Matrix => new[,]
        {
            {M11, M12, M13},
            {M21, M22, M23},
            {M31, M32, M33}
        };

        public float[] Array => new[]
        {
            M11, M12, M13,
            M21, M22, M23,
            M31, M32, M33
        };

        public static Matrix3 Identity =>
            new Matrix3
            (
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            );

        #region Constructors

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

        public static Matrix3 Add(in Matrix3 left, in Matrix3 right)
        {
            return left + right;
        }

        public static Matrix3 Add(in Matrix3 left, float right)
        {
            return left + right;
        }

        public static Matrix3 Subtract(in Matrix3 left, in Matrix3 right)
        {
            return left - right;
        }

        public static Matrix3 Subtract(in Matrix3 left, float right)
        {
            return left - right;
        }

        public static Matrix3 Multiply(in Matrix3 left, in Matrix3 right)
        {
            return left * right;
        }

        public static Matrix3 Multiply(in Matrix3 left, float right)
        {
            return left * right;
        }

        public static Matrix3 Divide(in Matrix3 left, float right)
        {
            return left / right;
        }

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

        #endregion

        #region Operators

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
    }
}
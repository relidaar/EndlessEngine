using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Math
{
    public struct Matrix4
    {
        public static (int m, int n) Size => (4, 4);
        public float[,] Matrix { get; }
        public float[] Array { get; }
        public IEnumerable<Vector4> Data => _data;
        private readonly Vector4[] _data;

        #region Constructors

        public Matrix4(float a11, float a12, float a13, float a14,
            float a21, float a22, float a23, float a24,
            float a31, float a32, float a33, float a34,
            float a41, float a42, float a43, float a44)
            : this(
                new Vector4(a11, a12, a13, a14),
                new Vector4(a21, a22, a23, a24),
                new Vector4(a31, a32, a33, a34),
                new Vector4(a41, a42, a43, a44)
            )
        {
        }

        public Matrix4(in Matrix4 matrix)
            : this(matrix.Data.ToArray())
        {
        }

        public Matrix4(params Vector4[] data)
        {
            if (data.Length != Size.m)
                throw new Exception("Data count should be equal to " + Size.m);

            _data = data;

            var arr = new List<float>();
            foreach (var vertex in _data)
                arr.AddRange(vertex.Data);

            Array = arr.ToArray();
            Matrix = MatrixOperations.ToMatrix(Array, Size.m, Size.n);
        }

        public Matrix4(in float value)
            : this(
                value, value, value, value,
                value, value, value, value,
                value, value, value, value,
                value, value, value, value
            )
        {
        }

        #endregion

        #region Operations

        public Matrix4 Add(Matrix4 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 + a2);
            return new Matrix4(result.ToArray());
        }

        public Matrix4 Subtract(Matrix4 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 - a2);
            return new Matrix4(result.ToArray());
        }

        public Matrix4 Multiply(float x)
        {
            var result = Data.Select(a => a * x);
            return new Matrix4(result.ToArray());
        }

        public Matrix4 Multiply(Matrix4 other)
        {
            var result = MatrixOperations.Multiply(Matrix, other.Matrix);

            var vertices = new Vector4[Size.m];
            for (var i = 0; i < Size.m; i++)
            {
                var row = new float[Size.n];
                for (var j = 0; j < Size.n; j++) row[j] = result[i, j];
                vertices[i] = new Vector4(row);
            }

            return new Matrix4(vertices);
        }

        public Matrix4 Transpose()
        {
            var result = MatrixOperations.Transpose(Matrix);

            var vertices = new Vector4[Size.m];
            for (var i = 0; i < Size.m; i++)
            {
                var row = new float[Size.n];
                for (var j = 0; j < Size.n; j++) row[j] = result[i, j];
                vertices[i] = new Vector4(row);
            }

            return new Matrix4(vertices);
        }

        public Matrix4 Invert()
        {
            var inverse = new float[16];

            inverse[0] = Array[5] * Array[10] * Array[15] -
                         Array[5] * Array[11] * Array[14] -
                         Array[9] * Array[6] * Array[15] +
                         Array[9] * Array[7] * Array[14] +
                         Array[13] * Array[6] * Array[11] -
                         Array[13] * Array[7] * Array[10];

            inverse[4] = -Array[4] * Array[10] * Array[15] +
                         Array[4] * Array[11] * Array[14] +
                         Array[8] * Array[6] * Array[15] -
                         Array[8] * Array[7] * Array[14] -
                         Array[12] * Array[6] * Array[11] +
                         Array[12] * Array[7] * Array[10];

            inverse[8] = Array[4] * Array[9] * Array[15] -
                         Array[4] * Array[11] * Array[13] -
                         Array[8] * Array[5] * Array[15] +
                         Array[8] * Array[7] * Array[13] +
                         Array[12] * Array[5] * Array[11] -
                         Array[12] * Array[7] * Array[9];

            inverse[12] = -Array[4] * Array[9] * Array[14] +
                          Array[4] * Array[10] * Array[13] +
                          Array[8] * Array[5] * Array[14] -
                          Array[8] * Array[6] * Array[13] -
                          Array[12] * Array[5] * Array[10] +
                          Array[12] * Array[6] * Array[9];

            inverse[1] = -Array[1] * Array[10] * Array[15] +
                         Array[1] * Array[11] * Array[14] +
                         Array[9] * Array[2] * Array[15] -
                         Array[9] * Array[3] * Array[14] -
                         Array[13] * Array[2] * Array[11] +
                         Array[13] * Array[3] * Array[10];

            inverse[5] = Array[0] * Array[10] * Array[15] -
                         Array[0] * Array[11] * Array[14] -
                         Array[8] * Array[2] * Array[15] +
                         Array[8] * Array[3] * Array[14] +
                         Array[12] * Array[2] * Array[11] -
                         Array[12] * Array[3] * Array[10];

            inverse[9] = -Array[0] * Array[9] * Array[15] +
                         Array[0] * Array[11] * Array[13] +
                         Array[8] * Array[1] * Array[15] -
                         Array[8] * Array[3] * Array[13] -
                         Array[12] * Array[1] * Array[11] +
                         Array[12] * Array[3] * Array[9];

            inverse[13] = Array[0] * Array[9] * Array[14] -
                          Array[0] * Array[10] * Array[13] -
                          Array[8] * Array[1] * Array[14] +
                          Array[8] * Array[2] * Array[13] +
                          Array[12] * Array[1] * Array[10] -
                          Array[12] * Array[2] * Array[9];

            inverse[2] = Array[1] * Array[6] * Array[15] -
                         Array[1] * Array[7] * Array[14] -
                         Array[5] * Array[2] * Array[15] +
                         Array[5] * Array[3] * Array[14] +
                         Array[13] * Array[2] * Array[7] -
                         Array[13] * Array[3] * Array[6];

            inverse[6] = -Array[0] * Array[6] * Array[15] +
                         Array[0] * Array[7] * Array[14] +
                         Array[4] * Array[2] * Array[15] -
                         Array[4] * Array[3] * Array[14] -
                         Array[12] * Array[2] * Array[7] +
                         Array[12] * Array[3] * Array[6];

            inverse[10] = Array[0] * Array[5] * Array[15] -
                          Array[0] * Array[7] * Array[13] -
                          Array[4] * Array[1] * Array[15] +
                          Array[4] * Array[3] * Array[13] +
                          Array[12] * Array[1] * Array[7] -
                          Array[12] * Array[3] * Array[5];

            inverse[14] = -Array[0] * Array[5] * Array[14] +
                          Array[0] * Array[6] * Array[13] +
                          Array[4] * Array[1] * Array[14] -
                          Array[4] * Array[2] * Array[13] -
                          Array[12] * Array[1] * Array[6] +
                          Array[12] * Array[2] * Array[5];

            inverse[3] = -Array[1] * Array[6] * Array[11] +
                         Array[1] * Array[7] * Array[10] +
                         Array[5] * Array[2] * Array[11] -
                         Array[5] * Array[3] * Array[10] -
                         Array[9] * Array[2] * Array[7] +
                         Array[9] * Array[3] * Array[6];

            inverse[7] = Array[0] * Array[6] * Array[11] -
                         Array[0] * Array[7] * Array[10] -
                         Array[4] * Array[2] * Array[11] +
                         Array[4] * Array[3] * Array[10] +
                         Array[8] * Array[2] * Array[7] -
                         Array[8] * Array[3] * Array[6];

            inverse[11] = -Array[0] * Array[5] * Array[11] +
                          Array[0] * Array[7] * Array[9] +
                          Array[4] * Array[1] * Array[11] -
                          Array[4] * Array[3] * Array[9] -
                          Array[8] * Array[1] * Array[7] +
                          Array[8] * Array[3] * Array[5];

            inverse[15] = Array[0] * Array[5] * Array[10] -
                          Array[0] * Array[6] * Array[9] -
                          Array[4] * Array[1] * Array[10] +
                          Array[4] * Array[2] * Array[9] +
                          Array[8] * Array[1] * Array[6] -
                          Array[8] * Array[2] * Array[5];

            var det = Array[0] * inverse[0] + Array[1] * inverse[4] + Array[2] * inverse[8] + Array[3] * inverse[12];

            if (det == 0)
                return new Matrix4(0);

            det = 1 / System.Math.Abs(det);

            for (var i = 0; i < 16; i++)
                inverse[i] = inverse[i] * det;

            var result = MatrixOperations.ToMatrix(inverse, Size.m, Size.n);
            var vertices = new Vector4[Size.m];
            for (var i = 0; i < Size.m; i++)
            {
                var row = new float[Size.n];
                for (var j = 0; j < Size.n; j++) row[j] = result[i, j];
                vertices[i] = new Vector4(row);
            }

            return new Matrix4(vertices);
        }

        #endregion

        #region Operators

        public static Matrix4 operator +(Matrix4 matrix1, in Matrix4 matrix2)
        {
            return matrix1.Add(matrix2);
        }

        public static Matrix4 operator -(Matrix4 matrix1, in Matrix4 matrix2)
        {
            return matrix1.Subtract(matrix2);
        }

        public static Matrix4 operator *(Matrix4 matrix, float x)
        {
            return matrix.Multiply(x);
        }

        public static Matrix4 operator *(Matrix4 matrix1, in Matrix4 matrix2)
        {
            return matrix1.Multiply(matrix2);
        }

        #endregion

        public static Matrix4 Identity =>
            new Matrix4
            (
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );

        #region Transformation Matrices

        public static Matrix4 Scaled(Vector3 vector)
        {
            return Scaled(vector.X, vector.Y, vector.Z);
        }

        public static Matrix4 Scaled(Vector2 vector)
        {
            return Scaled(vector.X, vector.Y);
        }

        public static Matrix4 Scaled(float x, float y, float z = 1)
        {
            return new Matrix4
            (
                x, 0, 0, 0,
                0, y, 0, 0,
                0, 0, z, 0,
                0, 0, 0, 1
            );
        }

        public static Matrix4 Translated(Vector3 vector)
        {
            return Translated(vector.X, vector.Y, vector.Z);
        }

        public static Matrix4 Translated(Vector2 vector)
        {
            return Translated(vector.X, vector.Y);
        }

        public static Matrix4 Translated(float x, float y, float z = 0)
        {
            return new Matrix4
            (
                1, 0, 0, x,
                0, 1, 0, y,
                0, 0, 1, z,
                0, 0, 0, 1
            );
        }

        public static Matrix4 Rotated(float angle, Vector3 vector)
        {
            return Rotated(angle, vector.X, vector.Y, vector.Z);
        }

        public static Matrix4 Rotated(float angle, float x, float y, float z)
        {
            var cos = (float) System.Math.Cos(angle);
            var sin = (float) System.Math.Sin(angle);

            return new Matrix4
            (
                // first row
                (float) (System.Math.Pow(x, 2) * (1 - cos) + cos),
                x * y * (1 - cos) - z * sin,
                x * z * (1 - cos) + y * sin,
                0,

                // second row
                x * y * (1 - cos) + z * sin,
                (float) (System.Math.Pow(y, 2) * (1 - cos) + cos),
                y * z * (1 - cos) - x * sin,
                0,

                // third row
                x * z * (1 - cos) - y * sin,
                y * z * (1 - cos) + x * sin,
                (float) (System.Math.Pow(z, 2) * (1 - cos) + cos),
                0,

                // fourth row
                0, 0, 0, 1
            );
        }

        #endregion

        #region View Projection Matrices

        public static Matrix4 Orthographic(float left, float right, float bottom, float top,
            float near = -1, float far = 1)
        {
            return new Matrix4
            (
                // first row
                2 / (right - left),
                0,
                0,
                -(right + left) / (right - left),

                // second row
                0,
                2 / (top - bottom),
                0,
                -(top + bottom) / (top - bottom),

                // third row
                0,
                0,
                -2 / (far - near),
                -(far + near) / (far - near),

                // fourth row
                0, 0, 0, 1
            );
        }

        #endregion
    }
}
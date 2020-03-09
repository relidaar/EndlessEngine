using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
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
            : this(matrix.Data as Vector4[])
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

        #endregion

        #region Operations

        public Matrix4 Add(Matrix4 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 + a2);
            return new Matrix4(result as Vector4[]);
        }

        public Matrix4 Subtract(Matrix4 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 - a2);
            return new Matrix4(result as Vector4[]);
        }

        public Matrix4 Multiply(float x)
        {
            var result = Data.Select(a => a * x);
            return new Matrix4(result as Vector4[]);
        }

        public Matrix4 Multiply(Matrix4 other)
        {
            var result = MatrixOperations.Multiply(Matrix, other.Matrix);

            var vertices = new Vector4[Size.m];
            var row = new float[Size.n];
            for (var i = 0; i < Size.m; i++)
            {
                for (int j = 0; j < Size.n; j++)
                {
                    row[j] = result[i, j];
                }            
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

        public static Matrix4 operator *(Matrix4 matrix1, float x)
        {
            return matrix1.Multiply(x);
        }

        public static Matrix4 operator *(Matrix4 matrix1, in Matrix4 matrix2)
        {
            return matrix1.Multiply(matrix2);
        }

        #endregion
        
        public static Matrix4 Scaled(Vector4 vertex)
        {
            var data = vertex.Data.ToArray();
            return Scaled(data[0], data[1], data[2]);
        }

        public static Matrix4 Scaled(Vector2 vertex)
        {
            var data = vertex.Data.ToArray();
            return Scaled(data[0], data[1], 1);
        }

        public static Matrix4 Scaled(float x, float y, float z)
        {
            return new Matrix4
            (
                x, 0, 0, 0,
                0, y, 0, 0,
                0, 0, z, 0,
                0, 0, 0, 1
            );
        }

        public static Matrix4 Translated(Vector4 vertex)
        {
            var data = vertex.Data.ToArray();
            return Translated(data[0], data[1], data[2]);
        }

        public static Matrix4 Translated(Vector2 vertex)
        {
            var data = vertex.Data.ToArray();
            return Translated(data[0], data[1], 1);
        }

        public static Matrix4 Translated(float x, float y, float z)
        {
            return new Matrix4
            (
                1, 0, 0, x,
                0, 1, 0, y,
                0, 0, 1, z,
                0, 0, 0, 1
            );
        }

        public static Matrix4 Identity =>
            new Matrix4
            (
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
    }
}
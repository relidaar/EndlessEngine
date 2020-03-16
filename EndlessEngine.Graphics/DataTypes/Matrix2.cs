using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix2
    {
        public static (int m, int n) Size => (2, 2);
        public float[,] Matrix { get; }
        public float[] Array { get; }
        public IEnumerable<Vector2> Data => _data;
        private readonly Vector2[] _data;

        #region Constructors

        public Matrix2(float a11, float a12, float a21, float a22)
            : this(
                new Vector2(a11, a12),
                new Vector2(a21, a22)
            )
        {
        }

        public Matrix2(in Matrix2 matrix)
            : this(matrix.Data.ToArray())
        {
        }

        public Matrix2(params Vector2[] data)
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

        public Matrix2 Add(Matrix2 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 + a2);
            return new Matrix2(result.ToArray());
        }

        public Matrix2 Subtract(Matrix2 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 - a2);
            return new Matrix2(result.ToArray());
        }

        public Matrix2 Multiply(float x)
        {
            var result = Data.Select(a => a * x);
            return new Matrix2(result.ToArray());
        }

        public Matrix2 Multiply(Matrix2 other)
        {
            var result = MatrixOperations.Multiply(Matrix, other.Matrix);

            var vertices = new Vector2[Size.m];
            for (var i = 0; i < Size.m; i++)
            {
                var row = new float[Size.n];
                for (int j = 0; j < Size.n; j++)
                {
                    row[j] = result[i, j];
                }            
                vertices[i] = new Vector2(row);
            }

            return new Matrix2(vertices);
        }

        #endregion

        #region Operators

        public static Matrix2 operator +(Matrix2 matrix1, in Matrix2 matrix2)
        {
            return matrix1.Add(matrix2);
        }

        public static Matrix2 operator -(Matrix2 matrix1, in Matrix2 matrix2)
        {
            return matrix1.Subtract(matrix2);
        }

        public static Matrix2 operator *(Matrix2 matrix, float x)
        {
            return matrix.Multiply(x);
        }

        public static Matrix2 operator *(Matrix2 matrix1, in Matrix2 matrix2)
        {
            return matrix1.Multiply(matrix2);
        }

        #endregion
        
        public static Matrix2 Identity =>
            new Matrix2
            (
                1, 0,
                0, 1
            );
    }
}
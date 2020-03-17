using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix3
    {
        public static (int m, int n) Size => (3, 3);
        public float[,] Matrix { get; }
        public float[] Array { get; }
        public IEnumerable<Vector3> Data => _data;
        private readonly Vector3[] _data;
        
        #region Constructors

        public Matrix3(float a11, float a12, float a13, float a21, float a22, float a23, float a31, float a32,
            float a33)
            : this(new Vector3(a11, a12, a13),
                new Vector3(a21, a22, a23),
                new Vector3(a31, a32, a33)
                )
        {
        }

        public Matrix3(in Matrix3 matrix)
            : this(matrix.Data.ToArray())
        {
        }

        public Matrix3(params Vector3[] data)
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

        public Matrix3(in float value)
            : this(
                value, value, value,
                value, value, value,
                value, value, value
                )
        {
        }

        #endregion

        #region Operations

        public Matrix3 Add(Matrix3 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 + a2);
            return new Matrix3(result.ToArray());
        }

        public Matrix3 Subtract(Matrix3 other)
        {
            var result = Data.Zip(other.Data, (a1, a2) => a1 - a2);
            return new Matrix3(result.ToArray());
        }

        public Matrix3 Multiply(float x)
        {
            var result = Data.Select(a => a * x);
            return new Matrix3(result.ToArray());
        }

        public Matrix3 Multiply(Matrix3 other)
        {
            var result = MatrixOperations.Multiply(Matrix, other.Matrix);

            var vertices = new Vector3[Size.m];
            for (var i = 0; i < Size.m; i++)
            {
                var row = new float[Size.n];
                for (int j = 0; j < Size.n; j++)
                {
                    row[j] = result[i, j];
                }            
                vertices[i] = new Vector3(row);
            }

            return new Matrix3(vertices);
        }

        #endregion

        #region Operators
        
        public static Matrix3 operator +(Matrix3 matrix1, in Matrix3 matrix2)
        {
            return matrix1.Add(matrix2);
        }

        public static Matrix3 operator -(Matrix3 matrix1, in Matrix3 matrix2)
        {
            return matrix1.Subtract(matrix2);
        }

        public static Matrix3 operator *(Matrix3 matrix1, float x)
        {
            return matrix1.Multiply(x);
        }

        public static Matrix3 operator *(Matrix3 matrix1, in Matrix3 matrix2)
        {
            return matrix1.Multiply(matrix2);
        }

        #endregion

        public static Matrix3 Identity =>
            new Matrix3
            (
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            );
    }
}
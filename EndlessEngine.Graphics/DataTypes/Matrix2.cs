using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix2
    {
        public IEnumerable<Vector2> Data => _data;
        private readonly Vector2[] _data;

        public Matrix2(float a11, float a12, float a21, float a22)
        {
            _data = new[]
            {
                new Vector2(a11, a12),
                new Vector2(a21, a22)
            };
        }

        public Matrix2(in Vector2 v1, in Vector2 v2)
        {
            _data = new[] {v1, v2};
        }

        public Matrix2(in Matrix2 m)
            : this(m.Data)
        {
        }

        private Matrix2(IEnumerable<Vector2> data)
        {
            _data = data.ToArray();
        }

        public static Matrix2 Identity =>
            new Matrix2
            (
                1, 0,
                0, 1
            );

        public Matrix2 Add(Matrix2 m)
        {
            var result = Data.Zip(m.Data, (a1, a2) => a1 + a2);
            return new Matrix2(result);
        }

        public static Matrix2 operator +(Matrix2 m1, in Matrix2 m2)
        {
            return m1.Add(m2);
        }

        public Matrix2 Subtract(Matrix2 m)
        {
            var result = Data.Zip(m.Data, (a1, a2) => a1 - a2);
            return new Matrix2(result);
        }

        public static Matrix2 operator -(Matrix2 m1, in Matrix2 m2)
        {
            return m1.Subtract(m2);
        }

        public Matrix2 Multiply(float x)
        {
            var result = Data.Select(a => a * x);
            return new Matrix2(result);
        }

        public static Matrix2 operator *(Matrix2 m1, float x)
        {
            return m1.Multiply(x);
        }

        public Matrix2 Multiply(Matrix2 m)
        {
            var a1 = ToMatrix();
            var a2 = m.ToMatrix();

            var result = MatrixOperations.Multiply(a1, a2);

            var vertices = new List<Vector2>();
            for (int i = 0; i < result.GetLength(0); i++)
            {
                vertices.Add(new Vector2(
                    result[i, 0],
                    result[i, 1]
                ));
            }

            return new Matrix2(vertices);
        }

        public static Matrix2 operator *(Matrix2 m1, in Matrix2 m2)
        {
            return m1.Multiply(m2);
        }

        public float[] ToArray()
        {
            var arr = new List<float>();
            foreach (var vertex in _data) arr.AddRange(vertex.Data);

            return arr.ToArray();
        }

        public float[,] ToMatrix()
        {
            return MatrixOperations.ToMatrix(ToArray(), 2, 2);
        }
    }
}
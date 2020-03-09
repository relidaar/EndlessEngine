using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix3
    {
        public IEnumerable<Vertex3> Data => _data;
        private readonly Vertex3[] _data;

        public Matrix3(float a11, float a12, float a13, float a21, float a22, float a23, float a31, float a32,
            float a33)
        {
            _data = new[]
            {
                new Vertex3(a11, a12, a13),
                new Vertex3(a21, a22, a23),
                new Vertex3(a31, a32, a33)
            };
        }

        public Matrix3(in Vertex3 v1, in Vertex3 v2, in Vertex3 v3)
        {
            _data = new[] {v1, v2, v3};
        }

        public Matrix3(in Matrix3 m)
            : this(m.Data)
        {
        }

        private Matrix3(IEnumerable<Vertex3> data)
        {
            _data = data.ToArray();
        }

        public static Matrix3 Identity =>
            new Matrix3
            (
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            );

        public Matrix3 Add(Matrix3 m)
        {
            var result = Data.Zip(m.Data, (a1, a2) => a1 + a2);
            return new Matrix3(result);
        }

        public static Matrix3 operator +(Matrix3 m1, in Matrix3 m2)
        {
            return m1.Add(m2);
        }

        public Matrix3 Subtract(Matrix3 m)
        {
            var result = Data.Zip(m.Data, (a1, a2) => a1 - a2);
            return new Matrix3(result);
        }

        public static Matrix3 operator -(Matrix3 m1, in Matrix3 m2)
        {
            return m1.Subtract(m2);
        }

        public Matrix3 Multiply(float x)
        {
            var result = Data.Select(a => a * x);
            return new Matrix3(result);
        }

        public static Matrix3 operator *(Matrix3 m1, float x)
        {
            return m1.Multiply(x);
        }

        public Matrix3 Multiply(Matrix3 m)
        {
            var a1 = ToMatrix();
            var a2 = m.ToMatrix();

            var result = MatrixOperations.Multiply(a1, a2);

            var vertices = new List<Vertex3>();
            for (int i = 0; i < result.GetLength(0); i++)
            {
                vertices.Add(new Vertex3(
                    result[i, 0],
                    result[i, 1],
                    result[i, 2]
                ));
            }

            return new Matrix3(vertices);
        }

        public static Matrix3 operator *(Matrix3 m1, in Matrix3 m2)
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
            return MatrixOperations.ToMatrix(ToArray(), 3, 3);
        }
    }
}
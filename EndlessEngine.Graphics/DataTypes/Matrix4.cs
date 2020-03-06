using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix4
    {
        public IEnumerable<Vertex4> Data => _data;
        private readonly Vertex4[] _data;
        
        public Matrix4(float a11, float a12, float a13, float a14,
            float a21, float a22, float a23, float a24,
            float a31, float a32, float a33, float a34,
            float a41, float a42, float a43, float a44)
        {
            _data = new[]
            {
                new Vertex4(a11, a12, a13, a14),
                new Vertex4(a21, a22, a23, a24),
                new Vertex4(a31, a32, a33, a34),
                new Vertex4(a41, a42, a43, a44)
            };
        }

        public Matrix4(in Vertex4 v1, in Vertex4 v2, in Vertex4 v3, in Vertex4 v4)
        {
            _data = new[] {v1, v2, v3, v4};
        }
        
        public Matrix4(in Matrix4 m)
            : this(m.Data)
        {
        }

        private Matrix4(IEnumerable<Vertex4> data)
        {
            _data = data.ToArray();
        }

        public Matrix4 Add(Matrix4 m)
        {
            var result = Data.Zip(m.Data, (a1, a2) => a1 + a2);
            return new Matrix4(result);
        }

        public static Matrix4 operator +(Matrix4 m1, in Matrix4 m2)
        {
            return m1.Add(m2);
        }

        public Matrix4 Subtract(Matrix4 m)
        {
            var result = Data.Zip(m.Data, (a1, a2) => a1 - a2);
            return new Matrix4(result);
        }

        public static Matrix4 operator -(Matrix4 m1, in Matrix4 m2)
        {
            return m1.Subtract(m2);
        }

        public Matrix4 Multiply(float x)
        {            
            var result = Data.Select(a => a * x);
            return new Matrix4(result);
        }

        public static Matrix4 operator *(Matrix4 m1, float x)
        {
            return m1.Multiply(x);
        }

        public Matrix4 Multiply(Matrix4 m)
        {
            var a1 = ToMatrix();
            var a2 = m.ToMatrix();

            var result = MatrixOperations.Multiply(a1, a2);

            return new Matrix4();
        }

        public static Matrix4 operator *(Matrix4 m1, in Matrix4 m2)
        {
            return m1.Multiply(m2);
        }

        public float[] ToArray()
        {
            var arr = new List<float>();
            foreach (var vertex in _data)
            {
                arr.AddRange(vertex.Data);
            }

            return arr.ToArray();
        }

        public float[,] ToMatrix()
        {
            return MatrixOperations.ToMatrix(ToArray(), 4, 4);
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
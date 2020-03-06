using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vertex4
    {
        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        public Vertex4(float a1, float a2, float a3, float a4)
        {
            _data = new[] {a1, a2, a3, a4};
        }

        private Vertex4(IEnumerable<float> data)
        {
            _data = data.ToArray();
        }

        public Vertex4(in Vertex4 v)
        {
            _data = v.Data.ToArray();
        }

        public Vertex4 Add(in Vertex4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vertex4(result);
        }

        public static Vertex4 operator +(Vertex4 v1, in Vertex4 v2)
        {
            return v1.Add(v2);
        }

        public Vertex4 Subtract(in Vertex4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vertex4(result);
        }

        public static Vertex4 operator -(Vertex4 v1, Vertex4 v2)
        {
            return v1.Subtract(v2);
        }

        public Vertex4 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vertex4(result);
        }

        public static Vertex4 operator *(Vertex4 v, float x)
        {
            return v.Multiply(x);
        }
    }
}
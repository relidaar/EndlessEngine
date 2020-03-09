using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vector4
    {
        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        public Vector4(float a1, float a2, float a3, float a4)
        {
            _data = new[] {a1, a2, a3, a4};
        }

        private Vector4(IEnumerable<float> data)
        {
            _data = data.ToArray();
        }

        public Vector4(in Vector4 v)
        {
            _data = v.Data.ToArray();
        }

        public Vector4 Add(in Vector4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vector4(result);
        }

        public static Vector4 operator +(Vector4 v1, in Vector4 v2)
        {
            return v1.Add(v2);
        }

        public Vector4 Subtract(in Vector4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vector4(result);
        }

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return v1.Subtract(v2);
        }

        public Vector4 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vector4(result);
        }

        public static Vector4 operator *(Vector4 v, float x)
        {
            return v.Multiply(x);
        }
    }
}
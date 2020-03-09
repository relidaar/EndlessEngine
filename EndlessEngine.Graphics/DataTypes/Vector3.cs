using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vector3
    {
        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        public Vector3(float a1, float a2, float a3)
        {
            _data = new[] {a1, a2, a3};
        }

        private Vector3(IEnumerable<float> data)
        {
            _data = data.ToArray();
        }

        public Vector3(in Vector3 v)
        {
            _data = v.Data.ToArray();
        }

        public Vector3 Add(in Vector3 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vector3(result);
        }

        public static Vector3 operator +(Vector3 v1, in Vector3 v2)
        {
            return v1.Add(v2);
        }

        public Vector3 Subtract(in Vector3 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vector3(result);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return v1.Subtract(v2);
        }

        public Vector3 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vector3(result);
        }

        public static Vector3 operator *(Vector3 v, float x)
        {
            return v.Multiply(x);
        }
    }
}
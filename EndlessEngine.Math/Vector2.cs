using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Math
{
    public struct Vector2
    {
        public static int Size => 2;
        public float X => _data[0];
        public float Y => _data[1];

        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        #region Constructors

        public Vector2(float value)
        {
            _data = new float[Size];
            for (var i = 0; i < Size; i++) _data[i] = value;
        }

        public Vector2(float x, float y)
        {
            _data = new[] {x, y};
        }

        public Vector2(params float[] data)
        {
            if (data.Length != Size)
                throw new Exception("Data count should be equal to " + Size);

            _data = data;
        }

        public Vector2(in Vector2 vector)
            : this(vector.Data.ToArray())
        {
        }

        #endregion

        #region Operations

        public Vector2 Add(in Vector2 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vector2(result.ToArray());
        }

        public Vector2 Subtract(in Vector2 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vector2(result.ToArray());
        }

        public Vector2 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vector2(result.ToArray());
        }

        #endregion

        #region Operators

        public static Vector2 operator +(Vector2 v1, in Vector2 v2)
        {
            return v1.Add(v2);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return v1.Subtract(v2);
        }

        public static Vector2 operator *(Vector2 v, float x)
        {
            return v.Multiply(x);
        }

        #endregion
    }
}
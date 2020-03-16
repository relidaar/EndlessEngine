using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vector4
    {
        public static int Size => 4;
        public float X => _data[0];
        public float Y => _data[1];
        public float Z => _data[2];
        public float W => _data[3];

        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        #region Constructors

        public Vector4(float value)
        {
            _data = new float[Size];
            for (int i = 0; i < Size; i++)
            {
                _data[i] = value;
            }
        }

        public Vector4(float x, float y, float z, float w)
        {
            _data = new[] {x, y, z, w};
        }

        public Vector4(params float[] data)
        {
            if (data.Length != Size)
                throw new Exception("Data count should be equal to " + Size);

            _data = data;
        }

        public Vector4(in Vector4 vector)
            : this(vector.Data.ToArray())
        {
        }

        #endregion

        #region Operations

        public Vector4 Add(in Vector4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vector4(result.ToArray());
        }

        public Vector4 Subtract(in Vector4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vector4(result.ToArray());
        }

        public Vector4 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vector4(result.ToArray());
        }

        #endregion

        #region Operators

        public static Vector4 operator +(Vector4 v1, in Vector4 v2)
        {
            return v1.Add(v2);
        }

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return v1.Subtract(v2);
        }

        public static Vector4 operator *(Vector4 v, float x)
        {
            return v.Multiply(x);
        }

        #endregion
    }
}
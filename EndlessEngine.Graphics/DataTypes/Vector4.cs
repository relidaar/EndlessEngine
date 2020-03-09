using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vector4
    {
        public float X => _data[0];
        public float Y => _data[1];
        public float Z => _data[2];
        public float W => _data[3];

        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        #region Constructors

        public Vector4(float a1, float a2, float a3, float a4)
        {
            _data = new[] {a1, a2, a3, a4};
        }

        private Vector4(params float[] data)
        {
            if (data.Length != 3)
                throw new Exception("Data count should be equal to 3");

            _data = data;
        }

        public Vector4(in Vector4 vector)
            : this(vector.Data as float[])
        {
        }

        #endregion

        #region Operations

        public Vector4 Add(in Vector4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vector4(result as float[]);
        }

        public Vector4 Subtract(in Vector4 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vector4(result as float[]);
        }

        public Vector4 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vector4(result as float[]);
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
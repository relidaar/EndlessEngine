using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vector3
    {
        public float X => _data[0];
        public float Y => _data[1];
        public float Z => _data[2];
        
        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        #region Constructors

        public Vector3(float x, float y, float z)
        {
            _data = new[] {x, y, z};
        }

        public Vector3(params float[] data)
        {
            if (data.Length != 3)
                throw new Exception("Data count should be equal to 3");
            
            _data = data;
        }

        public Vector3(in Vector3 v)
        {
            _data = v.Data as float[];
        }

        #endregion

        public Vector3 Add(in Vector3 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vector3(result as float[]);
        }

        public static Vector3 operator +(Vector3 v1, in Vector3 v2)
        {
            return v1.Add(v2);
        }

        public Vector3 Subtract(in Vector3 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vector3(result as float[]);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return v1.Subtract(v2);
        }

        public Vector3 Multiply(float x)
        {
            var result = _data.Select(a => a * x);
            return new Vector3(result as float[]);
        }

        public static Vector3 operator *(Vector3 v, float x)
        {
            return v.Multiply(x);
        }
    }
}
﻿namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix3
    {
        public float[] Data { get; private set; }

        public Matrix3(float a11, float a12, float a13,
            float a21, float a22, float a23,
            float a31, float a32, float a33)
        {
            Data = new[]
            {
                a11, a12, a13,
                a21, a22, a23,
                a31, a32, a33
            };
        }

        public Matrix3(params float[] data)
        {
            Data = new float[9];
            Set(data);
        }

        public void Set(params float[] data)
        {
            Data = new float[9];
            for (var i = 0; i < data.Length; i++) Data[i] = data[i];
        }

        public void Set(float a11, float a12, float a13,
            float a21, float a22, float a23,
            float a31, float a32, float a33)
        {
            Data = new[]
            {
                a11, a12, a13,
                a21, a22, a23,
                a31, a32, a33
            };
        }
    }
}
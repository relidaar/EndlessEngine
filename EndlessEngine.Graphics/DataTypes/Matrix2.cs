﻿namespace EndlessEngine.Graphics.DataTypes
{
    public struct Matrix2
    {
        public float[] Data { get; private set; }

        public Matrix2(float a11, float a12, float a21, float a22)
        {
            Data = new[]
            {
                a11, a12,
                a21, a22
            };
        }

        public Matrix2(params float[] data)
        {
            Data = new float[4];
            Set(data);
        }

        public void Set(params float[] data)
        {
            Data = new float[4];
            for (var i = 0; i < data.Length; i++) Data[i] = data[i];
        }

        public void Set(float a11, float a12, float a21, float a22)
        {
            Data = new[]
            {
                a11, a12,
                a21, a22
            };
        }
        
        public static Matrix2 Identity =>
            new Matrix2
            (
                1, 0,
                0, 1
            );
    }
}
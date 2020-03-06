using System;

namespace EndlessEngine.Graphics.DataTypes
{
    public static class MatrixOperations
    {
        public static float[,] Multiply(float[,] a, float[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                throw new Exception("n must be equal to p");

            var n = a.GetLength(1);
            var m = a.GetLength(0);
            var p = a.GetLength(0);

            var c = new float[n, p];
            for (var i = 0; i < p; i++)
            for (var j = 0; j < p; j++)
            {
                float sum = 0;
                for (var k = 0; k < m; k++) sum += a[i, k] * b[k, j];

                c[i, j] = sum;
            }

            return c;
        }

        public static float[,] ToMatrix(float[] data, int n, int m)
        {
            var arr = new float[n, m];
            for (var i = 0; i < n; i++)
            for (int j = 0, k = 0; j < m; j++, k++)
                arr[i, j] = data[k];

            return arr;
        }
    }
}
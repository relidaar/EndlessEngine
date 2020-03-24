using System;

namespace EndlessEngine.Math
{
    public static class MatrixOperations
    {
        public static float[,] Multiply(float[,] a, float[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                throw new Exception("Number of columns of A must be equal to number of rows of B");

            var m = a.GetLength(0);
            var n = a.GetLength(1);
            var p = b.GetLength(1);

            var c = new float[m, p];
            for (var i = 0; i < m; i++)
            for (var j = 0; j < p; j++)
            {
                float sum = 0;
                for (var k = 0; k < n; k++)
                    sum += a[i, k] * b[k, j];

                c[i, j] = sum;
            }

            return c;
        }

        public static float[,] ToMatrix(float[] data, int m, int n)
        {
            var arr = new float[m, n];
            var index = 0;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++, index++)
                arr[i, j] = data[index];

            return arr;
        }

        public static float[,] Transpose(float[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var transposed = new float[n, m];
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                transposed[j, i] = matrix[i, j];

            return transposed;
        }
    }
}
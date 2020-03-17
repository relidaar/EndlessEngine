using System;
using System.Linq;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
{
    public class Matrix4Tests
    {
        private static Vector4[] CreateVectors(float[] data)
        {
            var vectors = new Vector4[Matrix4.Size.m];
            for (int i = 0, j = 0; i < Matrix4.Size.m; i++, j += Matrix4.Size.n)
                vectors[i] = new Vector4(data[j..(j + Matrix4.Size.n)]);

            return vectors;
        }
        
        private static float[,] CreateMatrix(float[] data)
        {
            var matrix = new float[Matrix4.Size.m, Matrix4.Size.n];
            for (int i = 0, index = 0; i < Matrix4.Size.m; i++)
            for (int j = 0; j < Matrix4.Size.n; j++, index++)
                matrix[i, j] = data[index];

            return matrix;
        }

        #region Constructors

        [Theory]
        [InlineData(1f)]
        [InlineData(0f)]
        [InlineData(-1f)]
        public void CreateWithOneValue(float value)
        {
            var expected = new float[Matrix4.Size.m, Matrix4.Size.n];
            for (var i = 0; i < Matrix4.Size.m; i++)
            for (var j = 0; j < Matrix4.Size.n; j++)
                expected[i, j] = value;

            var result = new Matrix4(value).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            -1f, -2f, -3f, -4f,
            -5f, -6f, -7f, -8f,
            -9f, -10f, -11f, -12f,
            -13f, -14f, -15f, -16f
        )]
        [InlineData(
            1f, 2f, 3f, 4f,
            5f, 6f, 7f, 8f,
            9f, 10f, 11f, 12f,
            13f, 14f, 15f, 16f
        )]
        [InlineData(
            0f, 0f, 0f, 0f,
            0f, 0f, 0f, 0f,
            0f, 0f, 0f, 0f,
            0f, 0f, 0f, 0f
        )]
        public void CreateWithArrayOfVectors(params float[] data)
        {
            var vectors = CreateVectors(data);
            var result = new Matrix4(vectors).Array;

            Assert.Equal(data, result);
        }

        [Theory]
        [InlineData(
            -1f, -2f, -3f, -4f,
            -5f, -6f, -7f, -8f,
            -9f, -10f, -11f, -12f,
            -13f, -14f, -15f, -16f
        )]
        [InlineData(
            1f, 2f, 3f, 4f,
            5f, 6f, 7f, 8f,
            9f, 10f, 11f, 12f,
            13f, 14f, 15f, 16f
        )]
        [InlineData(
            0f, 0f, 0f, 0f,
            0f, 0f, 0f, 0f,
            0f, 0f, 0f, 0f,
            0f, 0f, 0f, 0f
        )]
        public void CreateWithMatrix(params float[] data)
        {
            var vectors = CreateVectors(data);
            var vector = new Matrix4(vectors);
            var result = new Matrix4(vector).Array;

            Assert.Equal(data, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void CreateWithArrayOfVectors_ThrowsException(int count)
        {
            var data = new Vector4[count];
            var result = Assert.Throws<Exception>(
                () => new Matrix4(data)
            );

            Assert.Equal($"Data count should be equal to {Matrix4.Size.m}", result.Message);
        }

        #endregion
    
        #region Operations

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        public void AddMatrix(params float[] data)
        {
            var vectors = CreateVectors(data);
            var matrix1 = new Matrix4(vectors);
            var matrix2 = new Matrix4(vectors);

            var result = matrix1.Add(matrix2);

            var expected = data.Select(x => x + x);

            Assert.Equal(expected, result.Array);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        public void SubtractMatrix(params float[] data)
        {
            var vectors = CreateVectors(data);
            var matrix1 = new Matrix4(vectors);
            var matrix2 = new Matrix4(vectors);

            var result = matrix1.Subtract(matrix2);

            var expected = data.Select(x => x - x);

            Assert.Equal(expected, result.Array);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        public void MultiplyMatrix(params float[] data)
        {
            var vectors = CreateVectors(data);
            var matrix1 = new Matrix4(vectors);
            var matrix2 = new Matrix4(vectors);

            var result = matrix1.Multiply(matrix2);

            var matrix = CreateMatrix(data);
            var expected = MatrixOperations.Multiply(matrix, matrix);

            Assert.Equal(expected, result.Matrix);
        }

        [Theory]
        [InlineData(1f)]
        [InlineData(0f)]
        [InlineData(-1f)]
        public void MultiplyByNumber(float value)
        {
            var expected = new float[Matrix4.Size.m, Matrix4.Size.n];
            for (var i = 0; i < Matrix4.Size.n; i++)
            for (var j = 0; j < Matrix4.Size.n; j++)
                expected[i, j] = value * value;

            var matrix = new Matrix4(value);
            var result = matrix.Multiply(value);

            Assert.Equal(expected, result.Matrix);
        }

        #endregion
  }
}
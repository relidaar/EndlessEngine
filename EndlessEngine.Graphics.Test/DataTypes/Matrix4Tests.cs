using System;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
{
    public class Matrix4Tests
    {
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
            {
                expected[i, j] = value;
            }
            
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
        public void CreateWithArray(params float[] data)
        {
            var result = new Matrix4(data).Array;
            
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

        private static Vector4[] CreateVectors(float[] data)
        {
            var vectors = new Vector4[Matrix4.Size.m];
            for (int i = 0, j = 0; i < Matrix4.Size.m; i++, j += Matrix4.Size.n)
                vectors[i] = new Vector4(data[j..(j + Matrix4.Size.n)]);
            
            return vectors;
        }
    }
}
using System;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
{
    public class Matrix2Tests
    {
        #region Constructors

        [Theory]
        [InlineData(1f)]
        [InlineData(0f)]
        [InlineData(-1f)]
        public void CreateWithOneValue(float value)
        {
            var expected = new float[Matrix2.Size.m, Matrix2.Size.n];
            for (var i = 0; i < Matrix2.Size.m; i++)
            for (var j = 0; j < Matrix2.Size.n; j++)
            {
                expected[i, j] = value;
            }
            
            var result = new Matrix2(value).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        public void CreateWithArrayOfVectors(params float[] data)
        {
            var vectors = CreateVectors(data);
            var result = new Matrix2(vectors).Array;
            
            Assert.Equal(data, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        public void CreateWithArray(params float[] data)
        {
            var result = new Matrix2(data).Array;
            
            Assert.Equal(data, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        public void CreateWithMatrix(params float[] data)
        {
            var vectors = CreateVectors(data);
            var vector = new Matrix2(vectors);
            var result = new Matrix2(vector).Array;
            
            Assert.Equal(data, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void CreateWithArrayOfVectors_ThrowsException(int count)
        {
            var data = new Vector2[count];
            var result = Assert.Throws<Exception>(
                () => new Matrix2(data)
            );
            
            Assert.Equal($"Data count should be equal to {Matrix2.Size.m}", result.Message);
        }

        #endregion

        private static Vector2[] CreateVectors(float[] data)
        {
            var vectors = new Vector2[Matrix2.Size.m];
            for (int i = 0, j = 0; i < Matrix2.Size.m; i++, j += Matrix2.Size.n)
                vectors[i] = new Vector2(data[j..(j + Matrix2.Size.n)]);
            
            return vectors;
        }
    }
}
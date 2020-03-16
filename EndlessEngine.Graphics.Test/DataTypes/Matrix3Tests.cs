using System;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
{
    public class Matrix3Tests
    {
        #region Constructors

        [Theory]
        [InlineData(1f)]
        [InlineData(0f)]
        [InlineData(-1f)]
        public void CreateWithOneValue(float value)
        {
            var expected = new float[Matrix3.Size.m, Matrix3.Size.n];
            for (var i = 0; i < Matrix3.Size.m; i++)
            for (var j = 0; j < Matrix3.Size.n; j++)
            {
                expected[i, j] = value;
            }
            
            var result = new Matrix3(value).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(
            -1f, -2f, -3f, 
            -4f, -5f, -6f, 
            -7f, -8f, -9f
        )]
        [InlineData(
            1f, 2f, 3f, 
            4f, 5f, 6f, 
            7f, 8f, 9f
        )]
        [InlineData(
            0f, 0f, 0f, 
            0f, 0f, 0f, 
            0f, 0f, 0f
        )]
        public void CreateWithArrayOfVectors(params float[] data)
        {
            var vectors = CreateVectors(data);
            var result = new Matrix3(vectors).Array;
            
            Assert.Equal(data, result);
        }
        
        [Theory]
        [InlineData(
            -1f, -2f, -3f, 
            -4f, -5f, -6f, 
            -7f, -8f, -9f
        )]
        [InlineData(
            1f, 2f, 3f, 
            4f, 5f, 6f, 
            7f, 8f, 9f
        )]
        [InlineData(
            0f, 0f, 0f, 
            0f, 0f, 0f, 
            0f, 0f, 0f
        )]
        public void CreateWithArray(params float[] data)
        {
            var result = new Matrix3(data).Array;
            
            Assert.Equal(data, result);
        }

        [Theory]
        [InlineData(
            -1f, -2f, -3f, 
            -4f, -5f, -6f, 
            -7f, -8f, -9f
        )]
        [InlineData(
            1f, 2f, 3f, 
            4f, 5f, 6f, 
            7f, 8f, 9f
        )]
        [InlineData(
            0f, 0f, 0f, 
            0f, 0f, 0f, 
            0f, 0f, 0f
        )]
        public void CreateWithMatrix(params float[] data)
        {
            var vectors = CreateVectors(data);
            var vector = new Matrix3(vectors);
            var result = new Matrix3(vector).Array;
            
            Assert.Equal(data, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void CreateWithArrayOfVectors_ThrowsException(int count)
        {
            var data = new Vector3[count];
            var result = Assert.Throws<Exception>(
                () => new Matrix3(data)
            );
            
            Assert.Equal($"Data count should be equal to {Matrix3.Size.m}", result.Message);
        }

        #endregion

        private static Vector3[] CreateVectors(float[] data)
        {
            var vectors = new Vector3[Matrix3.Size.m];
            for (int i = 0, j = 0; i < Matrix3.Size.m; i++, j += Matrix3.Size.n)
                vectors[i] = new Vector3(data[j..(j + Matrix3.Size.n)]);
            
            return vectors;
        }
    }
}
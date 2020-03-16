using System;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
{
    public class Vector2Tests
    {
        #region Constructors

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateWithOneValue(int value)
        {
            var expected = new float[Vector2.Size];
            for (int i = 0; i < Vector2.Size; i++)
            {
                expected[i] = value;
            }
            
            var result = new Vector2(value).Data;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 2f)]
        [InlineData(1f, -1f)]
        public void CreateWithArray(params float[] data)
        {
            var result = new Vector2(data).Data;
            Assert.Equal(data, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 2f)]
        [InlineData(1f, -1f)]
        public void CreateWithVector(params float[] data)
        {
            var vector = new Vector2(data);
            var result = new Vector2(vector).Data;
            Assert.Equal(vector.Data, result);
        }

        [Theory]
        [InlineData(new float[]{})]
        [InlineData(0f)]
        [InlineData(0f, 1f, 2f)]
        public void CreateWithArray_ThrowsException(params float[] data)
        {
            var result = Assert.Throws<Exception>(
                () => new Vector2(data)
            );
            
            Assert.Equal($"Data count should be equal to {Vector2.Size}", result.Message);
        }

        #endregion
        
        
    }
}
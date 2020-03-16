using System;
using System.Linq;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
{
    public class Vector2Tests
    {
        private readonly float[] _data = {1f, 2f};

        #region Constructors

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void CreateWithOneValue(float value)
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
        
        #region Operations

        [Theory]
        [InlineData(-1f, -2f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 2f)]
        [InlineData(1f, -1f)]
        public void AddVector(params float[] data)
        {
            var vector1 = new Vector2(data);
            var vector2 = new Vector2(data);
            
            var result = vector1.Add(vector2).Data;
            var expected = vector1.Data.Zip(vector2.Data,
                (a, b) => a + b
            );
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 2f)]
        [InlineData(1f, -1f)]
        public void SubtractVector(params float[] data)
        {
            var vector1 = new Vector2(data);
            var vector2 = new Vector2(data);
            
            var result = vector1.Subtract(vector2).Data;
            var expected = vector1.Data.Zip(vector2.Data,
                (a, b) => a - b
            );
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(1f)]
        [InlineData(-1f)]
        [InlineData(2f)]
        [InlineData(-2f)]
        public void MultiplyByNumber(float value)
        {
            var vector = new Vector2(_data);
            
            var result = vector.Multiply(value).Data;
            var expected = _data.Select(x => x * value);
            
            Assert.Equal(expected, result);
        }

        #endregion

        #region Operators

        [Theory]
        [InlineData(-1f, -2f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 2f)]
        [InlineData(1f, -1f)]
        public void AddVectorOperator(params float[] data)
        {
            var vector1 = new Vector2(data);
            var vector2 = new Vector2(data);
            
            var result = (vector1 + vector2).Data;
            var expected = vector1.Data.Zip(vector2.Data,
                (a, b) => a + b
            );
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 2f)]
        [InlineData(1f, -1f)]
        public void SubtractOperator(params float[] data)
        {
            var vector1 = new Vector2(data);
            var vector2 = new Vector2(data);
            
            var result = (vector1 - vector2).Data;
            var expected = vector1.Data.Zip(vector2.Data,
                (a, b) => a - b
            );
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(1f)]
        [InlineData(-1f)]
        [InlineData(2f)]
        [InlineData(-2f)]
        public void MultiplyByNumberOperator(float value)
        {
            var vector = new Vector2(_data);
            
            var result = (vector * value).Data;
            var expected = _data.Select(x => x * value);
            
            Assert.Equal(expected, result);
        }

        #endregion
    }
}
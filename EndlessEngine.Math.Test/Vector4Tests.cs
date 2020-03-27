using Xunit;

namespace EndlessEngine.Math.Test
{
    public class Vector4Tests
    {
        #region Constructors

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void CreateWithSingleValue(float value)
        {
            var result = new Vector4(value).Data;
            var expected = new[] {value, value, value, value};

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void CreateWithVector(float value)
        {
            var vector = new Vector4(value);
            var result = new Vector4(vector).Data;
            
            Assert.Equal(vector.Data, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(1f, -1f, 1f, -1f)]
        public void CreateWithValues(float x, float y, float z, float w)
        {
            var result = new Vector4(x, y, z, w).Data;
            var expected = new[] {x, y, z, w};

            Assert.Equal(expected, result);
        }

        #endregion

        #region Operations With Two Vectors

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(1f, -1f, 1f, -1f)]
        public void AddTwoVectors(float x, float y, float z, float w)
        {
            var left = new Vector4(x, y, z, w);
            var right = new Vector4(x, y, z, w);

            var result = (left + right).Data;
            var expected = new[]
            {
                x + x, 
                y + y,
                z + z,
                w + w
            };

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(1f, -1f, 1f, -1f)]
        public void SubtractTwoVectors(float x, float y, float z, float w)
        {
            var left = new Vector4(x, y, z, w);
            var right = new Vector4(x, y, z, w);

            var result = (left - right).Data;
            var expected = new[]
            {
                x - x, 
                y - y,
                z - z,
                w - w
            };

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(1f, -1f, 1f, -1f)]
        public void MultiplyTwoVectors(float x, float y, float z, float w)
        {
            var left = new Vector4(x, y, z, w);
            var right = new Vector4(x, y, z, w);

            var result = (left * right).Data;
            var expected = new[]
            {
                x * x, 
                y * y,
                z * z,
                w * w
            };

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -4f)]
        [InlineData(0f, 0f, 0f, 0f)]
        [InlineData(1f, 2f, 3f, 4f)]
        [InlineData(1f, -1f, 1f, -1f)]
        public void DivideTwoVectors(float x, float y, float z, float w)
        {
            var left = new Vector4(x, y, z, w);
            var right = new Vector4(x, y, z, w);

            var result = (left / right).Data;
            var expected = new[]
            {
                x / x, 
                y / y,
                z / z,
                w / w
            };

            Assert.Equal(expected, result);
        }
        
        #endregion

        #region Operations With Vector And Number

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void AddVectorAndNumber(float value)
        {
            var vector = new Vector4(value);
            var result = (vector + value).Data;
            var expected = new[]
            {
                value + value,
                value + value,
                value + value,
                value + value
            };

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void SubtractVectorWithNumber(float value)
        {
            var vector = new Vector4(value);
            var result = (vector - value).Data;
            var expected = new[]
            {
                value - value,
                value - value,
                value - value,
                value - value
            };

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void MultiplyVectorByNumber(float value)
        {
            var vector = new Vector4(value);
            var result = (vector * value).Data;
            var expected = new[]
            {
                value * value,
                value * value,
                value * value,
                value * value
            };

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void DivideVectorByNumber(float value)
        {
            var vector = new Vector4(value);
            var result = (vector / value).Data;
            var expected = new[]
            {
                value / value,
                value / value,
                value / value,
                value / value
            };

            Assert.Equal(expected, result);
        }

        #endregion
   }
}
using System.Linq;
using Xunit;

namespace EndlessEngine.Graphics.Test
{
    public class ColorTests
    {
        #region Constructors

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateWithSingleValue(int value)
        {
            var result = new Color(value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void CreateWithColor(params int[] data)
        {
            var color = new Color(data[0], data[1], data[2], data[3]);
            var result = new Color(color).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void CreateWithRGBAValues(params int[] data)
        {
            var result = new Color(data[0], data[1], data[2], data[3]).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        #endregion

        #region Operations

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void AddColor(params int[] data)
        {
            var color1 = new Color(0);
            var color2 = new Color(data[0], data[1], data[2], data[3]);

            var result = Color.Add(color1, color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void AddValue(int value)
        {
            var color = new Color(0);

            var result = Color.Add(color, value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void SubtractColor(params int[] data)
        {
            var color1 = new Color(0);
            var color2 = new Color(data[0], data[1], data[2], data[3]);

            var result = Color.Subtract(color1, color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(0 - x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void SubtractValue(int value)
        {
            var color = new Color(1);

            var result = Color.Subtract(color, value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(1 - value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void MultiplyByColor(params int[] data)
        {
            var color1 = new Color(1);
            var color2 = new Color(data[0], data[1], data[2], data[3]);

            var result = Color.Multiply(color1, color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void MultiplyByValue(int value)
        {
            var color = new Color(1);

            var result = Color.Multiply(color, value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void DivideByColor(params int[] data)
        {
            var color1 = new Color(data[0], data[1], data[2], data[3]);
            var color2 = new Color(1);

            var result = Color.Divide(color1, color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void DivideByValue(int value)
        {
            var color = new Color(1);

            var result = Color.Divide(color, value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(1 / value, 256);

            Assert.Equal(expected, result);
        }

        #endregion
   
        #region Operators

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void AddColorOperator(params int[] data)
        {
            var color1 = new Color(0);
            var color2 = new Color(data[0], data[1], data[2], data[3]);

            var result = (color1 + color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void AddValueOperator(int value)
        {
            var color = new Color(0);

            var result = (color + value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void SubtractColorOperator(params int[] data)
        {
            var color1 = new Color(0);
            var color2 = new Color(data[0], data[1], data[2], data[3]);

            var result = (color1 - color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(0 - x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void SubtractValueOperator(int value)
        {
            var color = new Color(1);

            var result = (color - value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(1 - value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void MultiplyByColorOperator(params int[] data)
        {
            var color1 = new Color(1);
            var color2 = new Color(data[0], data[1], data[2], data[3]);

            var result = (color1 * color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void MultiplyByValueOperator(int value)
        {
            var color = new Color(1);

            var result = (color * value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(value, 256);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, -2, -3, -4)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(256, 257, 258, 259)]
        public void DivideByColorOperator(params int[] data)
        {
            var color1 = new Color(data[0], data[1], data[2], data[3]);
            var color2 = new Color(1);

            var result = (color1 * color2).ValuesArray;
            var expected = data.Select(x => Color.Mod(x, 256));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void DivideByValueOperator(int value)
        {
            var color = new Color(1);

            var result = (color / value).ValuesArray;
            var expected = new int[4];
            for (var i = 0; i < expected.Length; i++) expected[i] = Color.Mod(1 / value, 256);

            Assert.Equal(expected, result);
        }

        #endregion
    }
}
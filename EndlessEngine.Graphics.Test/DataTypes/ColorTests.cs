using System.Linq;
using EndlessEngine.Graphics.DataTypes;
using Xunit;

namespace EndlessEngine.Graphics.Test.DataTypes
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
    }
}
using System;
using EndlessEngine.Math;
using Xunit;

namespace EndlessEngine.Graphics.Test
{
    public class SpriteTests
    {
        [Fact]
        public void CreateWithNullReferenceTexture()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new Sprite(null, 0, 0, 0));
            
            Assert.Throws<ArgumentNullException>(() => 
                new Sprite(null, 0, 0, 0, 0));
            
            Assert.Throws<ArgumentNullException>(() =>
                new Sprite(null, new Vector2(0), new Vector2(0)));
        }

        [Fact]
        public void CreateWithNegativeSize()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                new Sprite(null, 0, 0, -1));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                new Sprite(null, 0, 0, -1, -1));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                new Sprite(null, new Vector2(0), new Vector2(-1)));
        }
    }
}
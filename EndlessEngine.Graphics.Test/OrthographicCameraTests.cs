using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;
using Xunit;

namespace EndlessEngine.Graphics.Test
{
    public class OrthographicCameraTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        public void CreateWithSize(int width, int height)
        {
            ICamera camera = new OrthographicCamera(width, height);
            var expected = Matrix4.Orthographic(0, width, 0, height);
            
            Assert.Equal(expected, camera.ProjectionMatrix);
        }

        [Fact]
        public void CreateWithNegativeSize()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new OrthographicCamera(-1, -1));
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(-1, -1, -1, -1)]
        [InlineData(0, 0, 0, 0)]
        public void CreateWithPosition(int left, int right, int bottom, int top)
        {
            ICamera camera = new OrthographicCamera(left, right, bottom, top);
            var expected = Matrix4.Orthographic(left, right, bottom, top);
            
            Assert.Equal(expected, camera.ProjectionMatrix);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, -1, -1)]
        [InlineData(0, 0, 0)]
        public void SetPosition(float x, float y, float z)
        {
            ICamera camera = new OrthographicCamera(1, 1);
            camera.Position = new Vector3(x, y, z);
            
            Assert.Equal(x, camera.Position.X);
            Assert.Equal(y, camera.Position.Y);
            Assert.Equal(z, camera.Position.Z);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(0)]
        public void SetRotation(float rotation)
        {
            ICamera camera = new OrthographicCamera(1, 1);
            camera.Rotation = rotation;
            
            Assert.Equal(rotation, camera.Rotation);
        }
    }
}
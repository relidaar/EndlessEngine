using System.Collections.Generic;
using EndlessEngine.Graphics;
using EndlessEngine.Math;

namespace EndlessEngine.Sandbox
{
    public class Obstacle : IGameObject
    {
        private Vector2 _position;
        private Vector2 _size;

        #region Predefined Obstacles

        public static Obstacle Single(int width, int height, int x, int y)
        {
            var obstacle = new Obstacle
            {
                Color = Color.White,
                Width = width,
                Height = height,
                X = x,
                Y = y + height / 2
            };                   

            return obstacle;
        }

        public static IEnumerable<Obstacle> Multiple(int width, int height, int x, int y, int n)
        {
            var obstacles = new Obstacle[n];
            obstacles[0] = new Obstacle
            {
                Color = Color.White,
                Width = width,
                Height = height,
                X = x,
                Y = y + height / 2
            };                   

            for (int i = 1; i < n; i++)
            {
                obstacles[i] = new Obstacle
                {
                    Color = Color.White,
                    Width = width,
                    Height = height,
                    X = obstacles[i - 1].X + height / 2,
                    Y = y + height / 2
                };
            }

            return obstacles;
        }

        #endregion
        
        public int X
        {
            get => (int) Position.X;
            set => _position.X = value;
        }

        public int Y
        {
            get => (int) Position.Y;
            set => _position.Y = value;
        }

        public int Width
        {
            get => (int) Size.X;
            set => _size.X = value;
        }

        public int Height
        {
            get => (int) Size.Y;
            set => _size.Y = value;
        }

        public Vector2 Position => _position;
        public Vector2 Size => _size;
        public bool IsCollide(IGameObject other)
        {
            return X < other.X + other.Width &&
                   X + Width > other.X &&
                   Y < other.Y + other.Height &&
                   Y + Height > other.Y;
        }

        public Color Color { get; set; }
    }
}
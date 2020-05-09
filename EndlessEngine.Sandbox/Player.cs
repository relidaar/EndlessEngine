using EndlessEngine.Graphics;
using EndlessEngine.Math;

namespace EndlessEngine.Sandbox
{
    public class Player : IGameObject
    {
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
        public Color Color { get; set; }

        public int RunSpeed;
        public int JumpSpeed;
        public int FallSpeed;
        public int JumpHeight;
        public PlayerState State { get; set; }
        
        private Vector2 _position;
        private Vector2 _size;
    }

    public enum PlayerState
    {
        IsJumping,
        IsFalling,
        IsOnGround,
        IsDead
    }
}
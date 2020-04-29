using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;

namespace EndlessEngine.Graphics
{
    public class Sprite
    {
        public ITexture Texture { get; private set; }
        public Vector2 Position;
        public Vector2 Size;

        public Sprite(ITexture texture, int x, int y, int width, int height)
            : this(texture, new Vector2(x, y), new Vector2(width, height))
        {
        }

        public Sprite(ITexture texture, int x, int y, int size)
            : this(texture, new Vector2(x, y), new Vector2(size, size))
        {
        }
        
        public Sprite(ITexture texture, in Vector2 position, in Vector2 size)
        {
            if (size.X < 0 || size.Y < 0)
                throw new ArgumentOutOfRangeException();
            
            Texture = texture ?? throw new ArgumentNullException();
            Position = position;
            Size = size;
        }
    }
}
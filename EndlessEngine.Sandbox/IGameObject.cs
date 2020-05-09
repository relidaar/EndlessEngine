using EndlessEngine.Math;

namespace EndlessEngine.Sandbox
{
    public interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        
        Vector2 Position { get; }
        Vector2 Size { get; }
    }
}
using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface ICamera
    {
        Matrix4 ProjectionMatrix { get; }
        Matrix4 ViewMatrix { get; }
        Matrix4 ViewProjectionMatrix { get; }
        
        float Rotation { get; }
        Vector3 Position { get; }
    }
}
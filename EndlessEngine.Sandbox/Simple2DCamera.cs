using EndlessEngine.Graphics;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;

namespace EndlessEngine.Sandbox
{
    public class Simple2DCamera
    {
        public int X
        {
            get => (int) Camera.Position.X;
            set => Camera.Position = new Vector3(value, Camera.Position.Y, Camera.Position.Z);
        }

        public int Y
        {
            get => (int) Camera.Position.Y;
            set => Camera.Position = new Vector3(Camera.Position.X, value, Camera.Position.Z);
        }

        public ICamera Camera { get; }

        public Simple2DCamera(int x, int y)
        {
            Camera = new OrthographicCamera(x, y);
        }

        public Simple2DCamera(IWindow window)
        {
            Camera = new OrthographicCamera(window.Width, window.Height);
        }
    }
}
using EndlessEngine.Graphics;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using EndlessEngine.Math;

namespace EndlessEngine.Sandbox
{
    internal class Program
    {
        private static readonly IGraphicsFactory Graphics = new OpenGLGraphicsFactory();

        private static void Main(string[] args)
        {
            using var window = Graphics.CreateWindow(800, 600, "EndlessEngine");
            var camera = new OrthographicCamera(window.Width, window.Height);

            var renderer = Graphics.CreateRenderer();
            renderer.Init();
            
            var texture = Graphics.CreateTexture("assets/textures/test.jpg", TextureData.Default);
            var sprite = new Sprite(texture, 400, 300, 64);
            while (window.IsOpen)
            {
                renderer.SetClearColor(25, 25, 25);
                renderer.Clear();

                renderer.SetScene(camera);
                renderer.Draw(sprite);

                window.Display();
            }
        }
    }
}
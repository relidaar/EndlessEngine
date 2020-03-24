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
            var props = new WindowProperties
            {
                Width = 800,
                Height = 600,
                Title = "EndlessEngine"
            };

            using var window = Graphics.CreateWindow(props);

            var renderer = Graphics.CreateRenderer();
            renderer.Init();
            
            var camera = new OrthographicCamera(-1, 1, -1, 1);

            var texture = Graphics.CreateTexture("assets/textures/test.jpg", TextureData.Default);
            while (window.IsOpen)
            {
                renderer.SetClearColor(0.1f, 0.1f, 0.1f, 1);
                renderer.Clear();

                renderer.SetScene(camera);
                renderer.Draw(new Vector2(0.0f, 0), new Vector2(0.5f, 0.5f), texture);

                window.Display();
            }
        }
    }
}
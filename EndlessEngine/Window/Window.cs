using System;
using System.Collections.Generic;
using System.Text;
using EndlessEngine.System;
using GLFW;
using OpenGL;

namespace EndlessEngine.Window
{
    public class Window : IDisposable
    {
        public NativeWindow Instance { get; private set; }

        public Window(in WindowProperties properties) =>
            Create(properties);

        private void Create(in WindowProperties properties)
        {
            Instance = new NativeWindow(properties.Width, properties.Height, properties.Title);
            if (Instance == null)
            {
                Log.Instance.Error("Could not create window");
                throw new NullReferenceException("Could not create window");
            }

            Gl.Initialize();
            Glfw.MakeContextCurrent(Instance);

            Log.Instance.Info("Creating window \"{0}\" ({1}, {2})",
                properties.Title, properties.Width, properties.Height);
        }

        public bool IsOpen => !Glfw.WindowShouldClose(Instance);

        public void Display()
        {
            Glfw.PollEvents();
            Glfw.SwapBuffers(Instance);
        }

        public void Close()
        {
            Instance?.Dispose();
            Glfw.Terminate();
        }

        public void Dispose() => Close();
    }
}

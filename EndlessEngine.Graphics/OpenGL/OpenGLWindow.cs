using System;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Interfaces;
using GLFW;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLWindow : IWindow
    {
        public OpenGLWindow(in WindowProperties properties)
        {
            if (!Glfw.Init())
            {
                Log.Instance.Error("Could not initialize GLFW");
                Glfw.Terminate();
            }

            Gl.Initialize();

            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.Decorated, true);

            Instance = new NativeWindow(properties.Width, properties.Height, properties.Title);
            if (Instance == null)
            {
                Log.Instance.Error("Could not create window");
                throw new NullReferenceException("Could not create window");
            }

            Glfw.MakeContextCurrent(Instance);
            Instance.CenterOnScreen();

            Log.Instance.Info("Creating window \"{0}\" ({1}, {2})",
                properties.Title, properties.Width, properties.Height);
        }

        public NativeWindow Instance { get; }

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

        public void Dispose()
        {
            Close();
        }
    }
}
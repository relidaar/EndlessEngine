using System;
using System.IO;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Interfaces;
using GLFW;
using Newtonsoft.Json;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLWindow : IWindow
    {
        public OpenGLWindow(in WindowProperties properties, GraphicsSettings graphicsSettings = null)
        {
            if (!Glfw.Init())
            {
                Log.Instance.Error("Could not initialize GLFW");
                Glfw.Terminate();
            }

            Gl.Initialize();

            if (graphicsSettings == null)
            {
                using (var r = new StreamReader(Paths.GraphicsSettingsPath))
                {
                    var json = r.ReadToEnd();
                    graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(json);
                }
            }

            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, graphicsSettings.ApiVersionMajor);
            Glfw.WindowHint(Hint.ContextVersionMinor, graphicsSettings.ApiVersionMinor);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Doublebuffer, graphicsSettings.DoubleBuffer);
            Glfw.WindowHint(Hint.Decorated, graphicsSettings.Decorated);
            Glfw.WindowHint(Hint.Maximized, graphicsSettings.Maximized);
            Glfw.WindowHint(Hint.Resizable, graphicsSettings.Resizable);

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
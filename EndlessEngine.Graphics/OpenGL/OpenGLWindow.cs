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
        private readonly NativeWindow _instance;

        public OpenGLWindow(int width, int height, string title, GraphicsSettings graphicsSettings = null)
            : this(new WindowProperties {Width = width, Height = height, Title = title}, graphicsSettings)
        {
        }

        public OpenGLWindow(in WindowProperties properties, GraphicsSettings graphicsSettings = null)
        {
            if (!Glfw.Init())
            {
                Log.Instance.Error("Could not initialize GLFW");
                Glfw.Terminate();
            }

            Gl.Initialize();

            if (graphicsSettings == null)
                using (var r = new StreamReader(Paths.GraphicsSettingsPath))
                {
                    var json = r.ReadToEnd();
                    graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(json);
                }

            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, graphicsSettings.ApiVersionMajor);
            Glfw.WindowHint(Hint.ContextVersionMinor, graphicsSettings.ApiVersionMinor);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Doublebuffer, graphicsSettings.DoubleBuffer);
            Glfw.WindowHint(Hint.Decorated, graphicsSettings.Decorated);
            Glfw.WindowHint(Hint.Maximized, graphicsSettings.Maximized);
            Glfw.WindowHint(Hint.Resizable, graphicsSettings.Resizable);

            _instance = new NativeWindow(properties.Width, properties.Height, properties.Title);
            if (_instance == null)
            {
                Log.Instance.Error("Could not create window");
                throw new NullReferenceException("Could not create window");
            }

            Width = properties.Width;
            Height = properties.Height;
            
            Glfw.MakeContextCurrent(_instance);
            _instance.CenterOnScreen();

            Log.Instance.Info("Creating window \"{0}\" ({1}, {2})",
                properties.Title, properties.Width, properties.Height);
        }

        public int Width { get; }
        public int Height { get; }
        public bool IsOpen => !Glfw.WindowShouldClose(_instance);

        public void Display()
        {
            Glfw.PollEvents();
            Glfw.SwapBuffers(_instance);
        }

        public void Close()
        {
            _instance?.Dispose();
            Glfw.Terminate();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
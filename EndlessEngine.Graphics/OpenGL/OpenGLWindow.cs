﻿using System;
using System.IO;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Events;
using EndlessEngine.Graphics.Interfaces;
using GLFW;
using Newtonsoft.Json;
using OpenGL;
using Exception = System.Exception;
using MouseButton = EndlessEngine.Graphics.Interfaces.MouseButton;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLWindow : IWindow
    {
        private NativeWindow _instance;       
        
        public event EventHandler<IEvent> OnEvent;

        public OpenGLWindow(int width, int height, string title, in GraphicsSettings graphicsSettings)
        {
            Init(new WindowProperties {Width = width, Height = height, Title = title}, graphicsSettings);
        }

        public OpenGLWindow(int width, int height, string title)
        {
            GraphicsSettings graphicsSettings;
            using (var r = new StreamReader(Paths.GraphicsSettingsPath))
            {
                var json = r.ReadToEnd();
                graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(json);
            }
            
            Init(new WindowProperties {Width = width, Height = height, Title = title}, graphicsSettings);
        }

        public OpenGLWindow(in WindowProperties properties, in GraphicsSettings graphicsSettings)
        {
            Init(properties, graphicsSettings);
        }

        public OpenGLWindow(in WindowProperties properties)
        {
            GraphicsSettings graphicsSettings;
            using (var r = new StreamReader(Paths.GraphicsSettingsPath))
            {
                var json = r.ReadToEnd();
                graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(json);
            }
            
            Init(properties, graphicsSettings);
        }

        private void Init(in WindowProperties properties, in GraphicsSettings graphicsSettings)
        {
            if (!Glfw.Init())
            {
                Log.Instance.Error("Could not initialize GLFW");
                Glfw.Terminate();
            }

            Gl.Initialize();

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

            _instance.KeyAction += (sender, args) =>
            {
                switch (args.State)
                {
                    case InputState.Release:
                        OnEvent?.Invoke(sender, new KeyReleasedEvent((Key) args.Key));
                        break;
                    case InputState.Press:
                        OnEvent?.Invoke(sender, new KeyPressedEvent((Key) args.Key, 0));
                        break;
                    case InputState.Repeat:
                        OnEvent?.Invoke(sender, new KeyPressedEvent((Key) args.Key, 1));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };
            
            _instance.MouseButton += (sender, args) =>
            {
                switch (args.Action)
                {
                    case InputState.Release:
                        OnEvent?.Invoke(sender, new MouseButtonReleased((MouseButton) args.Button));
                        break;
                    case InputState.Press:
                        OnEvent?.Invoke(sender, new MouseButtonPressed((MouseButton) args.Button));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };

            _instance.MouseScroll += (sender, args) =>
                OnEvent?.Invoke(sender, new MouseScrolledEvent((float) args.X, (float) args.Y));

            _instance.MouseMoved += (sender, args) =>
                OnEvent?.Invoke(sender, new MouseMovedEvent((float) args.X, (float) args.Y));
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
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
using System;
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

            Glfw.SetKeyCallback(_instance,
                (window, key, code, state, mods) =>
                {
                    var keyCode = (Key) code;
                    if (Enum.IsDefined(typeof(Key), keyCode))
                    {
                        throw new Exception("Undefined key");
                    }

                    switch (state)
                    {
                        case InputState.Release:
                            OnEvent?.Invoke(_instance, new KeyReleasedEvent(keyCode));
                            break;
                        case InputState.Press:
                            OnEvent?.Invoke(_instance, new KeyPressedEvent(keyCode, 0));
                            break;
                        case InputState.Repeat:
                            OnEvent?.Invoke(_instance, new KeyPressedEvent(keyCode, 1));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(state), state, null);
                    }
                });
            
            Glfw.SetMouseButtonCallback(_instance,
                (window, button, state, modifiers) =>
                {
                    var buttonCode = (MouseButton) button;
                    if (!Enum.IsDefined(typeof(MouseButton), buttonCode))
                    {
                        throw new Exception("Undefined Mouse Button");
                    }
                    
                    switch (state)
                    {
                        case InputState.Release:
                            OnEvent?.Invoke(_instance, new MouseButtonReleased(buttonCode));
                            break;
                        case InputState.Press:
                            OnEvent?.Invoke(_instance, new MouseButtonPressed(buttonCode));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(state), state, null);
                    }
                });

            Glfw.SetScrollCallback(_instance, (window, xOffset, yOffset) =>
            {
                OnEvent?.Invoke(_instance, new MouseScrolledEvent((float) xOffset, (float) yOffset));
            });

            Glfw.SetCursorPositionCallback(_instance, (window, x, y) =>
            {
                OnEvent?.Invoke(_instance, new MouseMovedEvent((float) x, (float) y));;
            });
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
// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLWindow.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Events;
using EndlessEngine.Graphics.Interfaces;
using GLFW;
using Newtonsoft.Json;
using OpenGL;
using MouseButton = EndlessEngine.Graphics.Interfaces.MouseButton;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLWindow.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IWindow" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IWindow" />
    public class OpenGLWindow : IWindow
    {
        /// <summary>
        /// The window instance
        /// </summary>
        private NativeWindow _instance;

        #region Events

        /// <summary>
        /// Occurs when [on event].
        /// </summary>
        public event EventHandler<IEvent> OnEvent;

        /// <summary>
        /// Occurs when [on window close].
        /// </summary>
        public event EventHandler<WindowCloseEvent> OnWindowClose;
        
        /// <summary>
        /// Occurs when [on window moved].
        /// </summary>
        public event EventHandler<WindowMovedEvent> OnWindowMoved;
        
        /// <summary>
        /// Occurs when [on window resize].
        /// </summary>
        public event EventHandler<WindowResizeEvent> OnWindowResize;
        
        /// <summary>
        /// Occurs when [on window focus].
        /// </summary>
        public event EventHandler<WindowFocusEvent> OnWindowFocus;

        /// <summary>
        /// Occurs when [on key pressed].
        /// </summary>
        public event EventHandler<KeyPressedEvent> OnKeyPressed;
        
        /// <summary>
        /// Occurs when [on key released].
        /// </summary>
        public event EventHandler<KeyReleasedEvent> OnKeyReleased;
        
        /// <summary>
        /// Occurs when [on key typed].
        /// </summary>
        public event EventHandler<KeyTypedEvent> OnKeyTyped;

        /// <summary>
        /// Occurs when [on mouse button pressed].
        /// </summary>
        public event EventHandler<MouseButtonPressedEvent> OnMouseButtonPressed;
        
        /// <summary>
        /// Occurs when [on mouse button released].
        /// </summary>
        public event EventHandler<MouseButtonReleasedEvent> OnMouseButtonReleased;
        
        /// <summary>
        /// Occurs when [on mouse scrolled].
        /// </summary>
        public event EventHandler<MouseScrolledEvent> OnMouseScrolled;
        
        /// <summary>
        /// Occurs when [on mouse moved].
        /// </summary>
        public event EventHandler<MouseMovedEvent> OnMouseMoved;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLWindow"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLWindow(int width, int height, string title, in GraphicsSettings graphicsSettings)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException();

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

            Init(new WindowProperties {Width = width, Height = height, Title = title}, graphicsSettings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLWindow"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLWindow(int width, int height, string title)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException();

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
            
            GraphicsSettings graphicsSettings;
            using (var r = new StreamReader(Paths.GraphicsSettingsPath))
            {
                var json = r.ReadToEnd();
                graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(json);
            }
            
            Init(new WindowProperties {Width = width, Height = height, Title = title}, graphicsSettings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLWindow"/> class.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        public OpenGLWindow(in WindowProperties properties, in GraphicsSettings graphicsSettings)
        {
            Init(properties, graphicsSettings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLWindow"/> class.
        /// </summary>
        /// <param name="properties">The properties.</param>
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

        /// <summary>
        /// Initializes the specified properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        /// <exception cref="NullReferenceException">Could not create window</exception>
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

            _instance.Closed += (sender, args) =>
            {
                OnEvent?.Invoke(sender, new WindowCloseEvent());
                OnWindowClose?.Invoke(sender, new WindowCloseEvent());
            };

            _instance.PositionChanged += (sender, args) =>
            {
                OnEvent?.Invoke(sender, new WindowMovedEvent());
                OnWindowMoved?.Invoke(sender, new WindowMovedEvent());
            };

            _instance.SizeChanged += (sender, args) =>
            {
                OnEvent?.Invoke(sender, new WindowResizeEvent(args.Size.Width, args.Size.Height));
                OnWindowResize?.Invoke(sender, new WindowResizeEvent(args.Size.Width, args.Size.Height));
            };

            _instance.FocusChanged += (sender, args) =>
            {
                OnEvent?.Invoke(sender, new WindowFocusEvent());
                OnWindowFocus?.Invoke(sender, new WindowFocusEvent());
            };

            _instance.KeyAction += (sender, args) =>
            {
                switch (args.State)
                {
                    case InputState.Release:
                        OnEvent?.Invoke(sender, new KeyReleasedEvent((Key) args.Key));
                        OnKeyReleased?.Invoke(sender, new KeyReleasedEvent((Key) args.Key));
                        break;
                    case InputState.Press:
                        OnEvent?.Invoke(sender, new KeyPressedEvent((Key) args.Key, 0));
                        OnKeyPressed?.Invoke(sender, new KeyPressedEvent((Key) args.Key, 0));
                        break;
                    case InputState.Repeat:
                        OnEvent?.Invoke(sender, new KeyPressedEvent((Key) args.Key, 1));
                        OnKeyPressed?.Invoke(sender, new KeyPressedEvent((Key) args.Key, 1));
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
                        OnEvent?.Invoke(sender, new MouseButtonReleasedEvent((MouseButton) args.Button));
                        OnMouseButtonReleased?.Invoke(sender, new MouseButtonReleasedEvent((MouseButton) args.Button));
                        break;
                    case InputState.Press:
                        OnEvent?.Invoke(sender, new MouseButtonPressedEvent((MouseButton) args.Button));
                        OnMouseButtonPressed?.Invoke(sender, new MouseButtonPressedEvent((MouseButton) args.Button));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };

            _instance.MouseScroll += (sender, args) =>
            {
                OnEvent?.Invoke(sender, new MouseScrolledEvent((float) args.X, (float) args.Y));
                OnMouseScrolled?.Invoke(sender, new MouseScrolledEvent((float) args.X, (float) args.Y));
            };

            _instance.MouseMoved += (sender, args) =>
            {
                OnEvent?.Invoke(sender, new MouseMovedEvent((float) args.X, (float) args.Y));
                OnMouseMoved?.Invoke(sender, new MouseMovedEvent((float) args.X, (float) args.Y));
            };
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; private set; }
        
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; private set; }
        
        /// <summary>
        /// Gets a value indicating whether the window is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        public bool IsOpen => !Glfw.WindowShouldClose(_instance);

        /// <summary>
        /// Displays the window.
        /// </summary>
        public void Display()
        {
            Glfw.PollEvents();
            Glfw.SwapBuffers(_instance);
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        public void Close()
        {
            _instance?.Dispose();
            Glfw.Terminate();
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="IWindow.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using EndlessEngine.Graphics.Events;

namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IWindow
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IWindow : IDisposable
    {
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        int Width { get; }
        
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        int Height { get; }

        /// <summary>
        /// Gets a value indicating whether the window is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        bool IsOpen { get; }
        
        /// <summary>
        /// Displays the window.
        /// </summary>
        void Display();
        
        /// <summary>
        /// Closes the window.
        /// </summary>
        void Close();

        #region Events

        /// <summary>
        /// Occurs when [on event].
        /// </summary>
        event EventHandler<IEvent> OnEvent;

        /// <summary>
        /// Occurs when [on window close].
        /// </summary>
        event EventHandler<WindowCloseEvent> OnWindowClose;
        /// <summary>
        /// Occurs when [on window moved].
        /// </summary>
        event EventHandler<WindowMovedEvent> OnWindowMoved;
        /// <summary>
        /// Occurs when [on window resize].
        /// </summary>
        event EventHandler<WindowResizeEvent> OnWindowResize;
        /// <summary>
        /// Occurs when [on window focus].
        /// </summary>
        event EventHandler<WindowFocusEvent> OnWindowFocus;

        /// <summary>
        /// Occurs when [on key pressed].
        /// </summary>
        event EventHandler<KeyPressedEvent> OnKeyPressed;
        /// <summary>
        /// Occurs when [on key released].
        /// </summary>
        event EventHandler<KeyReleasedEvent> OnKeyReleased;
        /// <summary>
        /// Occurs when [on key typed].
        /// </summary>
        event EventHandler<KeyTypedEvent> OnKeyTyped;

        /// <summary>
        /// Occurs when [on mouse button pressed].
        /// </summary>
        event EventHandler<MouseButtonPressedEvent> OnMouseButtonPressed;
        /// <summary>
        /// Occurs when [on mouse button released].
        /// </summary>
        event EventHandler<MouseButtonReleasedEvent> OnMouseButtonReleased;
        /// <summary>
        /// Occurs when [on mouse scrolled].
        /// </summary>
        event EventHandler<MouseScrolledEvent> OnMouseScrolled;
        /// <summary>
        /// Occurs when [on mouse moved].
        /// </summary>
        event EventHandler<MouseMovedEvent> OnMouseMoved;

        #endregion
    }
}
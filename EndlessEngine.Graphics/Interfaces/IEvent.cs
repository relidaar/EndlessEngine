// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-25-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="IEvent.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IEvent
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        EventType Type { get; }
    }

    /// <summary>
    /// Enum EventType
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// The window close event
        /// </summary>
        WindowClose,
        /// <summary>
        /// The window resize event
        /// </summary>
        WindowResize,
        /// <summary>
        /// The window focus event
        /// </summary>
        WindowFocus,
        /// <summary>
        /// The window lost focus event
        /// </summary>
        WindowLostFocus,
        /// <summary>
        /// The window moved event
        /// </summary>
        WindowMoved,

        /// <summary>
        /// The key pressed event
        /// </summary>
        KeyPressed,
        /// <summary>
        /// The key released event
        /// </summary>
        KeyReleased,
        /// <summary>
        /// The key typed event
        /// </summary>
        KeyTyped,

        /// <summary>
        /// The mouse button pressed event
        /// </summary>
        MouseButtonPressed,
        /// <summary>
        /// The mouse button released event
        /// </summary>
        MouseButtonReleased,
        /// <summary>
        /// The mouse moved event
        /// </summary>
        MouseMoved,
        /// <summary>
        /// The mouse scrolled event
        /// </summary>
        MouseScrolled
    }
}
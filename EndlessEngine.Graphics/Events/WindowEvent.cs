// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-25-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="WindowEvent.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.Events
{
    /// <summary>
    /// Class WindowCloseEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class WindowCloseEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowCloseEvent"/> class.
        /// </summary>
        public WindowCloseEvent()
        {
            Type = EventType.WindowClose;
        }
    }

    /// <summary>
    /// Class WindowResizeEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class WindowResizeEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; }
        
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowResizeEvent"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public WindowResizeEvent(int width, int height)
        {
            Width = width;
            Height = height;
            Type = EventType.WindowResize;
        }
    }

    /// <summary>
    /// Class WindowFocusEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class WindowFocusEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowFocusEvent"/> class.
        /// </summary>
        public WindowFocusEvent()
        {
            Type = EventType.WindowFocus;
        }
    }

    /// <summary>
    /// Class WindowLostFocusEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class WindowLostFocusEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowLostFocusEvent"/> class.
        /// </summary>
        public WindowLostFocusEvent()
        {
            Type = EventType.WindowLostFocus;
        }
    }

    /// <summary>
    /// Class WindowMovedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class WindowMovedEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowMovedEvent"/> class.
        /// </summary>
        public WindowMovedEvent()
        {
            Type = EventType.WindowMoved;
        }
    }
}
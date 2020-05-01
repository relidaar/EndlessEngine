// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-25-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="MouseEvent.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.Events
{
    /// <summary>
    /// Class MouseMovedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class MouseMovedEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        /// <value>The x.</value>
        public float X { get; }
        
        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        /// <value>The y.</value>
        public float Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseMovedEvent"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public MouseMovedEvent(float x, float y)
        {
            Type = EventType.MouseMoved;
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Class MouseScrolledEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public class MouseScrolledEvent : IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the x offset.
        /// </summary>
        /// <value>The x offset.</value>
        public float XOffset { get; }
        
        /// <summary>
        /// Gets the y offset.
        /// </summary>
        /// <value>The y offset.</value>
        public float YOffset { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseScrolledEvent"/> class.
        /// </summary>
        /// <param name="xOffset">The x offset.</param>
        /// <param name="yOffset">The y offset.</param>
        public MouseScrolledEvent(float xOffset, float yOffset)
        {
            Type = EventType.MouseScrolled;
            XOffset = xOffset;
            YOffset = yOffset;
        }
    }

    /// <summary>
    /// Class MouseButtonPressedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IMouseButtonEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IMouseButtonEvent" />
    public class MouseButtonPressedEvent : IMouseButtonEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the mouse button.
        /// </summary>
        /// <value>The mouse button.</value>
        public MouseButton Button { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseButtonPressedEvent"/> class.
        /// </summary>
        /// <param name="button">The mouse button.</param>
        public MouseButtonPressedEvent(MouseButton button)
        {
            Type = EventType.MouseButtonPressed;
            Button = button;
        }
    }

    /// <summary>
    /// Class MouseButtonReleasedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IMouseButtonEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IMouseButtonEvent" />
    public class MouseButtonReleasedEvent : IMouseButtonEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the mouse button.
        /// </summary>
        /// <value>The mouse button.</value>
        public MouseButton Button { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseButtonReleasedEvent"/> class.
        /// </summary>
        /// <param name="button">The mouse button.</param>
        public MouseButtonReleasedEvent(MouseButton button)
        {
            Type = EventType.MouseButtonReleased;
            Button = button;
        }
    }
}
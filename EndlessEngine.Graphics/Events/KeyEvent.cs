// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-25-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="KeyEvent.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.Events
{
    /// <summary>
    /// Class KeyPressedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IKeyEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IKeyEvent" />
    public class KeyPressedEvent : IKeyEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public Key Key { get; }
        
        /// <summary>
        /// Gets the repeat count.
        /// </summary>
        /// <value>The repeat count.</value>
        public int RepeatCount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPressedEvent"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="repeatCount">The repeat count.</param>
        public KeyPressedEvent(Key key, int repeatCount)
        {
            Type = EventType.KeyPressed;
            Key = key;
            RepeatCount = repeatCount;
        }
    }

    /// <summary>
    /// Class KeyReleasedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IKeyEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IKeyEvent" />
    public class KeyReleasedEvent : IKeyEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public Key Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyReleasedEvent"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public KeyReleasedEvent(Key key)
        {
            Type = EventType.KeyReleased;
            Key = key;
        }
    }

    /// <summary>
    /// Class KeyTypedEvent.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IKeyEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IKeyEvent" />
    public class KeyTypedEvent : IKeyEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }
        
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public Key Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyTypedEvent"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public KeyTypedEvent(Key key)
        {
            Type = EventType.KeyTyped;
            Key = key;
        }
    }
}
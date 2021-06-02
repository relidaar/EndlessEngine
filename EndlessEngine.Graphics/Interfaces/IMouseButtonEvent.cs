// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-25-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="IMouseButtonEvent.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IMouseButtonEvent
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public interface IMouseButtonEvent : IEvent
    {
        /// <summary>
        /// Gets the mouse button.
        /// </summary>
        /// <value>The mouse button.</value>
        MouseButton Button { get; }
    }

    /// <summary>
    /// Enum MouseButton
    /// </summary>
    public enum MouseButton
    {
        /// <summary>
        /// The button0
        /// </summary>
        Button0 = 0,
        /// <summary>
        /// The button1
        /// </summary>
        Button1 = 1,
        /// <summary>
        /// The button2
        /// </summary>
        Button2 = 2,
        /// <summary>
        /// The button3
        /// </summary>
        Button3 = 3,
        /// <summary>
        /// The button4
        /// </summary>
        Button4 = 4,
        /// <summary>
        /// The button5
        /// </summary>
        Button5 = 5,
        /// <summary>
        /// The button6
        /// </summary>
        Button6 = 6,
        /// <summary>
        /// The button7
        /// </summary>
        Button7 = 7,
        /// <summary>
        /// The button8
        /// </summary>
        Button8 = 8,
        /// <summary>
        /// The button9
        /// </summary>
        Button9 = 9,

        /// <summary>
        /// The left button
        /// </summary>
        Left = Button0,
        /// <summary>
        /// The right button
        /// </summary>
        Right = Button1,
        /// <summary>
        /// The middle button
        /// </summary>
        Middle = Button2
    }
}
// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-25-2020
//
// Last Modified By : alexs
// Last Modified On : 04-25-2020
// ***********************************************************************
// <copyright file="IKeyEvent.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IKeyEvent
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IEvent" />
    public interface IKeyEvent : IEvent
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        Key Key { get; }
    }

    /// <summary>
    /// Enum Key
    /// </summary>
    public enum Key
    {
        /// <summary>
        /// The space
        /// </summary>
        Space = 32,
        /// <summary>
        /// The apostrophe
        /// </summary>
        Apostrophe = 39,
        /// <summary>
        /// The comma
        /// </summary>
        Comma = 44,
        /// <summary>
        /// The minus
        /// </summary>
        Minus = 45,
        /// <summary>
        /// The period
        /// </summary>
        Period = 46,
        /// <summary>
        /// The slash
        /// </summary>
        Slash = 47,

        /// <summary>
        /// The alpha0
        /// </summary>
        Alpha0 = 48,
        /// <summary>
        /// The alpha1
        /// </summary>
        Alpha1 = 49,
        /// <summary>
        /// The alpha2
        /// </summary>
        Alpha2 = 50,
        /// <summary>
        /// The alpha3
        /// </summary>
        Alpha3 = 51,
        /// <summary>
        /// The alpha4
        /// </summary>
        Alpha4 = 52,
        /// <summary>
        /// The alpha5
        /// </summary>
        Alpha5 = 53,
        /// <summary>
        /// The alpha6
        /// </summary>
        Alpha6 = 54,
        /// <summary>
        /// The alpha7
        /// </summary>
        Alpha7 = 55,
        /// <summary>
        /// The alpha8
        /// </summary>
        Alpha8 = 56,
        /// <summary>
        /// The alpha9
        /// </summary>
        Alpha9 = 57,

        /// <summary>
        /// The semi colon
        /// </summary>
        SemiColon = 59,
        /// <summary>
        /// The equal
        /// </summary>
        Equal = 61,

        /// <summary>
        /// a
        /// </summary>
        A = 65,
        /// <summary>
        /// The b
        /// </summary>
        B = 66,
        /// <summary>
        /// The c
        /// </summary>
        C = 67,
        /// <summary>
        /// The d
        /// </summary>
        D = 68,
        /// <summary>
        /// The e
        /// </summary>
        E = 69,
        /// <summary>
        /// The f
        /// </summary>
        F = 70,
        /// <summary>
        /// The g
        /// </summary>
        G = 71,
        /// <summary>
        /// The h
        /// </summary>
        H = 72,
        /// <summary>
        /// The i
        /// </summary>
        I = 73,
        /// <summary>
        /// The j
        /// </summary>
        J = 74,
        /// <summary>
        /// The k
        /// </summary>
        K = 75,
        /// <summary>
        /// The l
        /// </summary>
        L = 76,
        /// <summary>
        /// The m
        /// </summary>
        M = 77,
        /// <summary>
        /// The n
        /// </summary>
        N = 78,
        /// <summary>
        /// The o
        /// </summary>
        O = 79,
        /// <summary>
        /// The p
        /// </summary>
        P = 80,
        /// <summary>
        /// The q
        /// </summary>
        Q = 81,
        /// <summary>
        /// The r
        /// </summary>
        R = 82,
        /// <summary>
        /// The s
        /// </summary>
        S = 83,
        /// <summary>
        /// The t
        /// </summary>
        T = 84,
        /// <summary>
        /// The u
        /// </summary>
        U = 85,
        /// <summary>
        /// The v
        /// </summary>
        V = 86,
        /// <summary>
        /// The w
        /// </summary>
        W = 87,
        /// <summary>
        /// The x
        /// </summary>
        X = 88,
        /// <summary>
        /// The y
        /// </summary>
        Y = 89,
        /// <summary>
        /// The z
        /// </summary>
        Z = 90,

        /// <summary>
        /// The left bracket
        /// </summary>
        LeftBracket = 91,
        /// <summary>
        /// The backslash
        /// </summary>
        Backslash = 92,
        /// <summary>
        /// The right bracket
        /// </summary>
        RightBracket = 93,
        /// <summary>
        /// The grave accent
        /// </summary>
        GraveAccent = 96,
        /// <summary>
        /// The world1
        /// </summary>
        World1 = 161,
        /// <summary>
        /// The world2
        /// </summary>
        World2 = 162,
        /// <summary>
        /// The escape
        /// </summary>
        Escape = 256,
        /// <summary>
        /// The enter
        /// </summary>
        Enter = 257,
        /// <summary>
        /// The tab
        /// </summary>
        Tab = 258,
        /// <summary>
        /// The backspace
        /// </summary>
        Backspace = 259,
        /// <summary>
        /// The insert
        /// </summary>
        Insert = 260,
        /// <summary>
        /// The delete
        /// </summary>
        Delete = 261,
        /// <summary>
        /// The right
        /// </summary>
        Right = 262,
        /// <summary>
        /// The left
        /// </summary>
        Left = 263,
        /// <summary>
        /// Down
        /// </summary>
        Down = 264,
        /// <summary>
        /// Up
        /// </summary>
        Up = 265,
        /// <summary>
        /// The page up
        /// </summary>
        PageUp = 266,
        /// <summary>
        /// The page down
        /// </summary>
        PageDown = 267,
        /// <summary>
        /// The home
        /// </summary>
        Home = 268,
        /// <summary>
        /// The end
        /// </summary>
        End = 269,
        /// <summary>
        /// The caps lock
        /// </summary>
        CapsLock = 280,
        /// <summary>
        /// The scroll lock
        /// </summary>
        ScrollLock = 281,
        /// <summary>
        /// The number lock
        /// </summary>
        NumLock = 282,
        /// <summary>
        /// The print screen
        /// </summary>
        PrintScreen = 283,
        /// <summary>
        /// The pause
        /// </summary>
        Pause = 284,

        /// <summary>
        /// The f1
        /// </summary>
        F1 = 290,
        /// <summary>
        /// The f2
        /// </summary>
        F2 = 291,
        /// <summary>
        /// The f3
        /// </summary>
        F3 = 292,
        /// <summary>
        /// The f4
        /// </summary>
        F4 = 293,
        /// <summary>
        /// The f5
        /// </summary>
        F5 = 294,
        /// <summary>
        /// The f6
        /// </summary>
        F6 = 295,
        /// <summary>
        /// The f7
        /// </summary>
        F7 = 296,
        /// <summary>
        /// The f8
        /// </summary>
        F8 = 297,
        /// <summary>
        /// The f9
        /// </summary>
        F9 = 298,
        /// <summary>
        /// The F10
        /// </summary>
        F10 = 299,
        /// <summary>
        /// The F11
        /// </summary>
        F11 = 300,
        /// <summary>
        /// The F12
        /// </summary>
        F12 = 301,
        /// <summary>
        /// The F13
        /// </summary>
        F13 = 302,
        /// <summary>
        /// The F14
        /// </summary>
        F14 = 303,
        /// <summary>
        /// The F15
        /// </summary>
        F15 = 304,
        /// <summary>
        /// The F16
        /// </summary>
        F16 = 305,
        /// <summary>
        /// The F17
        /// </summary>
        F17 = 306,
        /// <summary>
        /// The F18
        /// </summary>
        F18 = 307,
        /// <summary>
        /// The F19
        /// </summary>
        F19 = 308,
        /// <summary>
        /// The F20
        /// </summary>
        F20 = 309,
        /// <summary>
        /// The F21
        /// </summary>
        F21 = 310,
        /// <summary>
        /// The F22
        /// </summary>
        F22 = 311,
        /// <summary>
        /// The F23
        /// </summary>
        F23 = 312,
        /// <summary>
        /// The F24
        /// </summary>
        F24 = 313,
        /// <summary>
        /// The F25
        /// </summary>
        F25 = 314,

        /// <summary>
        /// The numpad0
        /// </summary>
        Numpad0 = 320,
        /// <summary>
        /// The numpad1
        /// </summary>
        Numpad1 = 321,
        /// <summary>
        /// The numpad2
        /// </summary>
        Numpad2 = 322,
        /// <summary>
        /// The numpad3
        /// </summary>
        Numpad3 = 323,
        /// <summary>
        /// The numpad4
        /// </summary>
        Numpad4 = 324,
        /// <summary>
        /// The numpad5
        /// </summary>
        Numpad5 = 325,
        /// <summary>
        /// The numpad6
        /// </summary>
        Numpad6 = 326,
        /// <summary>
        /// The numpad7
        /// </summary>
        Numpad7 = 327,
        /// <summary>
        /// The numpad8
        /// </summary>
        Numpad8 = 328,
        /// <summary>
        /// The numpad9
        /// </summary>
        Numpad9 = 329,

        /// <summary>
        /// The numpad decimal
        /// </summary>
        NumpadDecimal = 330,
        /// <summary>
        /// The numpad divide
        /// </summary>
        NumpadDivide = 331,
        /// <summary>
        /// The numpad multiply
        /// </summary>
        NumpadMultiply = 332,
        /// <summary>
        /// The numpad subtract
        /// </summary>
        NumpadSubtract = 333,
        /// <summary>
        /// The numpad add
        /// </summary>
        NumpadAdd = 334,
        /// <summary>
        /// The numpad enter
        /// </summary>
        NumpadEnter = 335,
        /// <summary>
        /// The numpad equal
        /// </summary>
        NumpadEqual = 336,

        /// <summary>
        /// The left shift
        /// </summary>
        LeftShift = 340,
        /// <summary>
        /// The left control
        /// </summary>
        LeftControl = 341,
        /// <summary>
        /// The left alt
        /// </summary>
        LeftAlt = 342,
        /// <summary>
        /// The left super
        /// </summary>
        LeftSuper = 343,
        /// <summary>
        /// The right shift
        /// </summary>
        RightShift = 344,
        /// <summary>
        /// The right control
        /// </summary>
        RightControl = 345,
        /// <summary>
        /// The right alt
        /// </summary>
        RightAlt = 346,
        /// <summary>
        /// The right super
        /// </summary>
        RightSuper = 347,
        /// <summary>
        /// The menu
        /// </summary>
        Menu = 348
    }
}
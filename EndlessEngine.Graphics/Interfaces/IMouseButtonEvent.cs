﻿namespace EndlessEngine.Graphics.Interfaces
{
    public interface IMouseButtonEvent : IEvent
    {
        MouseButton Button { get; }
    }

    public enum MouseButton
    {
        Button0 = 0,
        Button1 = 1,
        Button2 = 2,
        Button3 = 3,
        Button4 = 4,
        Button5 = 5,
        Button6 = 6,
        Button7 = 7,
        Button8 = 8,
        Button9 = 9,
        
        Left = Button0,
        Right = Button1,
        Middle = Button2
    }
}
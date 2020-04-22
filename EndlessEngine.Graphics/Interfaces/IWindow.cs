using System;
using EndlessEngine.Graphics.Events;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IWindow : IDisposable
    {
        int Width { get; }
        int Height { get; }
        
        bool IsOpen { get; }
        void Display();
        void Close();

        #region Events
        
        event EventHandler<IEvent> OnEvent;

        event EventHandler<WindowCloseEvent> OnWindowClose;
        event EventHandler<WindowMovedEvent> OnWindowMoved;
        event EventHandler<WindowResizeEvent> OnWindowResize;
        event EventHandler<WindowFocusEvent> OnWindowFocus;

        event EventHandler<KeyPressedEvent> OnKeyPressed;
        event EventHandler<KeyReleasedEvent> OnKeyReleased;
        event EventHandler<KeyTypedEvent> OnKeyTyped;
        
        event EventHandler<MouseButtonPressedEvent> OnMouseButtonPressed;
        event EventHandler<MouseButtonReleasedEvent> OnMouseButtonReleased;
        event EventHandler<MouseScrolledEvent> OnMouseScrolled;
        event EventHandler<MouseMovedEvent> OnMouseMoved;

        #endregion
    }
}
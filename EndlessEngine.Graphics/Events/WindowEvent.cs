using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.Events
{
    public class WindowCloseEvent : IEvent
    {
        public EventType Type { get; }

        public WindowCloseEvent()
        {
            Type = EventType.WindowClose;
        }
    }

    public class WindowResizeEvent : IEvent
    {
        public EventType Type { get; }
        
        public int Width { get; }
        public int Height { get; }
        
        public WindowResizeEvent(int width, int height)
        {
            Width = width;
            Height = height;
            Type = EventType.WindowResize;
        }
    }
    
    public class WindowFocusEvent : IEvent
    {
        public EventType Type { get; }

        public WindowFocusEvent()
        {
            Type = EventType.WindowFocus;
        }
    }
    
    public class WindowLostFocusEvent : IEvent
    {
        public EventType Type { get; }

        public WindowLostFocusEvent()
        {
            Type = EventType.WindowLostFocus;
        }
    }

    public class WindowMovedEvent : IEvent
    {
        public EventType Type { get; }

        public WindowMovedEvent()
        {
            Type = EventType.WindowMoved;
        }
    }
}
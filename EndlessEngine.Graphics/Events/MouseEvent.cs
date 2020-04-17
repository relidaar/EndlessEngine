using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.Events
{
    public class MouseMovedEvent : IEvent
    {
        public EventType Type { get; }
        public float X { get; }
        public float Y { get; }

        public MouseMovedEvent(float x, float y)
        {
            Type = EventType.MouseMoved;
            X = x;
            Y = y;
        }
    }
    
    public class MouseScrolledEvent : IEvent
    {
        public EventType Type { get; }
        public float XOffset { get; }
        public float YOffset { get; }

        public MouseScrolledEvent(float xOffset, float yOffset)
        {
            Type = EventType.MouseScrolled;
            XOffset = xOffset;
            YOffset = yOffset;
        }
    }
    
    public class MouseButtonPressed : IMouseButtonEvent
    {
        public EventType Type { get; }
        public MouseButton Button { get; }

        public MouseButtonPressed(MouseButton button)
        {
            Type = EventType.MouseButtonPressed;
            Button = button;
        }
    }
    
    public class MouseButtonReleased : IMouseButtonEvent
    {
        public EventType Type { get; }
        public MouseButton Button { get; }

        public MouseButtonReleased(MouseButton button)
        {
            Type = EventType.MouseButtonReleased;
            Button = button;
        }
    }
}
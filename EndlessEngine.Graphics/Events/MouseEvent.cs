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
    
    public class MouseButtonPressedEvent : IMouseButtonEvent
    {
        public EventType Type { get; }
        public MouseButton Button { get; }

        public MouseButtonPressedEvent(MouseButton button)
        {
            Type = EventType.MouseButtonPressed;
            Button = button;
        }
    }
    
    public class MouseButtonReleasedEvent : IMouseButtonEvent
    {
        public EventType Type { get; }
        public MouseButton Button { get; }

        public MouseButtonReleasedEvent(MouseButton button)
        {
            Type = EventType.MouseButtonReleased;
            Button = button;
        }
    }
}
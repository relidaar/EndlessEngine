using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.Events
{
    public class KeyPressedEvent : IKeyEvent
    {
        public EventType Type { get; }
        public Key Key { get; }
        public int RepeatCount { get; }

        public KeyPressedEvent(Key key, int repeatCount)
        {
            Type = EventType.KeyPressed;
            Key = key;
            RepeatCount = repeatCount;
        }
    }

    public class KeyReleasedEvent : IKeyEvent
    {
        public EventType Type { get; }
        public Key Key { get; }

        public KeyReleasedEvent(Key key)
        {
            Type = EventType.KeyReleased;
            Key = key;
        }
    }
    
    public class KeyTypedEvent : IKeyEvent
    {
        public EventType Type { get; }
        public Key Key { get; }
        
        public KeyTypedEvent(Key key)
        {
            Type = EventType.KeyTyped;
            Key = key;
        }
    }
}
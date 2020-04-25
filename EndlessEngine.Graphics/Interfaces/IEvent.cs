namespace EndlessEngine.Graphics.Interfaces
{
    public interface IEvent
    {
        EventType Type { get; }
    }

    public enum EventType
    {
        WindowClose, 
        WindowResize, 
        WindowFocus, 
        WindowLostFocus, 
        WindowMoved,
        
        KeyPressed,
        KeyReleased,
        KeyTyped,
        
        MouseButtonPressed,
        MouseButtonReleased,
        MouseMoved,
        MouseScrolled
    }
}
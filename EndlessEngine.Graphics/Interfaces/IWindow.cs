using System;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IWindow : IDisposable
    {
        int Width { get; }
        int Height { get; }
        
        bool IsOpen { get; }
        void Display();
        void Close();

        event EventHandler<IEvent> OnEvent;
    }
}
using System;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IWindow : IDisposable
    {
        bool IsOpen { get; }
        void Display();
        void Close();
    }
}
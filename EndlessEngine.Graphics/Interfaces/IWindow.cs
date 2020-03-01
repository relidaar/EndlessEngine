using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IWindow : IDisposable
    {
        bool IsOpen { get; }
        void Display();
        void Close();
    }
}

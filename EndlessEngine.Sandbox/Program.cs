using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EndlessEngine.Sandbox
{
    public class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        public static void Main(string[] args)
        {
#if !DEBUG
            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(h, 0);
#endif
            var game = new Game(800, 600, "Sample Game");
            game.Run();
        }
    }
}
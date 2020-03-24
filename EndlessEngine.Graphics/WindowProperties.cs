namespace EndlessEngine.Graphics
{
    public struct WindowProperties
    {
        public int Width;
        public int Height;
        public string Title;
        public int X;
        public int Y;

        public WindowProperties(int width, int height, string title, int x, int y)
        {
            Width = width;
            Height = height;
            Title = title;
            X = x;
            Y = y;
        }
    }
}
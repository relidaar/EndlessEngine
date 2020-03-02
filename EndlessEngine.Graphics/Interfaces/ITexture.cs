namespace EndlessEngine.Graphics.Interfaces
{
    public interface ITexture
    {
        int Width { get; }
        int Height { get; }

        void Bind(uint slot = 0);
    }
}
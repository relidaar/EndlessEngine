namespace EndlessEngine.Graphics.Interfaces
{
    public interface IShaderLibrary
    {
        void Add(IShader shader);
        IShader Load(string name, string vertexShaderPath, string fragmentShaderPath);

        IShader Get(string name);
    }
}
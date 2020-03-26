using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IRenderer
    {
        void Init(IShader shader, IVertexArray vertexArray);
        void Init();
        void UseDefaultShader();
        
        void Clear();
        void SetClearColor(Color color);
        void SetClearColor(int r, int g, int b, int a = 255);
        void SetClearColor(float r, float g, float b, float a = 1f);
        
        void SetScene(ICamera camera);
        void SetScene(ICamera camera, IShader shader);
        
        void Draw(IShader shader, IVertexArray vertexArray, Matrix4 transform);
        void Draw(Vector2 position, Vector2 size, Color color);
        void Draw(Vector2 position, Vector2 size, ITexture texture, float tilingFactor = 1.0f);
    }
}
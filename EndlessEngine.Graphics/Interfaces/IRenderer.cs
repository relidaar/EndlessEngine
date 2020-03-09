using EndlessEngine.Graphics.DataTypes;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IRenderer
    {
        void Init(IShader shader, IVertexArray vertexArray);
        void Init();
        void Clear();
        void SetClearColor(Color color);
        void SetClearColor(float r, float g, float b, float a);
        void Draw(IShader shader, IVertexArray vertexArray, Matrix4 transform);
        void Draw(Vector2 position, Vector2 size, Color color);
    }
}
using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IShader
    {
        string Name { get; }
        void Bind();
        void Unbind();
        void SetUniform(string name, float value);
        void SetUniform(string name, float v1, float v2);
        void SetUniform(string name, float v1, float v2, float v3);
        void SetUniform(string name, float v1, float v2, float v3, float v4);

        void SetUniform(string name, int value);
        void SetUniform(string name, int v1, int v2);
        void SetUniform(string name, int v1, int v2, int v3);
        void SetUniform(string name, int v1, int v2, int v3, int v4);

        void SetUniform(string name, Vector2 vertex);
        void SetUniform(string name, Vector3 vertex);
        void SetUniform(string name, Vector4 vertex);

        void SetUniform(string name, bool transpose, Matrix2 matrix);
        void SetUniform(string name, bool transpose, Matrix3 matrix);
        void SetUniform(string name, bool transpose, Matrix4 matrix);
    }
}
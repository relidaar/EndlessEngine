using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IShader
    {
        string Name { get; }
        void Bind();
        void Unbind();

        #region Uniforms
        
        void SetUniform(string name, float value);
        void SetUniform(string name, float v1, float v2);
        void SetUniform(string name, float v1, float v2, float v3);
        void SetUniform(string name, float v1, float v2, float v3, float v4);

        void SetUniform(string name, int value);
        void SetUniform(string name, int v1, int v2);
        void SetUniform(string name, int v1, int v2, int v3);
        void SetUniform(string name, int v1, int v2, int v3, int v4);

        void SetUniform(string name, in Vector2 vertex);
        void SetUniform(string name, in Vector3 vertex);
        void SetUniform(string name, in Vector4 vertex);

        void SetUniform(string name, bool transpose, in Matrix2 matrix);
        void SetUniform(string name, bool transpose, in Matrix3 matrix);
        void SetUniform(string name, bool transpose, in Matrix4 matrix);

        #endregion
    }
}
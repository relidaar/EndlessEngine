namespace EndlessEngine.Graphics.Interfaces
{
    public interface IShader
    {
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

        void SetUniform(string name, MatrixUniformType type, bool transposed, float[] data);
    }

    public enum MatrixUniformType
    {
        Matrix2,
        Matrix3,
        Matrix4
    }
}

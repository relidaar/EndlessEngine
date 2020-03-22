namespace EndlessEngine.Graphics.DataTypes
{
    public class GraphicsData
    {
        #region DefaultShaderData

        public string ShaderName;
        public string VertexShaderPath;
        public string FragmentShaderPath;

        public string VerticesPosition;
        public string TextureCoordinates;

        public string ViewProjectionUniform;
        public string TransformUniform;
        public string TextureUniform;
        public string ColorUniform;
        public string TilingFactorUniform;

        #endregion
    }
}
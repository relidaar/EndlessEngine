namespace EndlessEngine.Graphics
{
    public struct BufferElement
    {
        public string Name;
        public ShaderDataType Type;
        public int Size;
        public int Offset;
        public bool Normalized;

        public BufferElement(ShaderDataType type, string name, bool normalized = false)
        {
            Name = name;
            Type = type;
            Size = ShaderData.ShaderDataTypeSize(type);
            Offset = 0;
            Normalized = normalized;
        }
    }
}
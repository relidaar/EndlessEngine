﻿namespace EndlessEngine.Graphics.Interfaces
{
    public interface IRenderer
    {
        void Clear();
        void SetClearColor(Color color);
        void SetClearColor(float r, float g, float b, float a);
        void DrawIndexed(IVertexArray vertexArray);
    }
}
using System;
using System.Linq;
using EndlessEngine.Graphics.DataTypes;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;
using Vertex3 = EndlessEngine.Graphics.DataTypes.Vertex3;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLRenderer : IRenderer
    {
        private IShader _shader;
        private IVertexArray _vertexArray;

        public void Init(IShader shader, IVertexArray vertexArray)
        {
            if (shader == null || vertexArray == null)
                throw new ArgumentNullException();

            _shader = shader;
            _vertexArray = vertexArray;

            Init();
        }

        public void Init()
        {
            Gl.Enable(EnableCap.Blend);
            Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public void Clear()
        {
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void SetClearColor(Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            Gl.ClearColor(r, g, b, a);
        }

        public void SetClearColor(float r, float g, float b, float a)
        {
            Gl.ClearColor(r, g, b, a);
        }

        private static void DrawIndexed(IVertexArray vertexArray)
        {
            Gl.DrawElements(
                PrimitiveType.Triangles,
                vertexArray.IndexBuffer.Count,
                DrawElementsType.UnsignedInt,
                null);
        }

        public void Draw(IShader shader, IVertexArray vertexArray, Matrix4 transform)
        {
            if (shader == null || vertexArray == null) 
                throw new ArgumentNullException();

            shader.Bind();
            shader.SetUniform("uTransform", false, transform);

            vertexArray.Bind();
            DrawIndexed(vertexArray);
        }

        public void Draw(Vertex2 position, Vertex2 size, Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);

            _shader.Bind();
            _shader.SetUniform("uTransform", true, transform);
            _shader.SetUniform("uColor", r, g, b, a);

            _vertexArray.Bind();
            DrawIndexed(_vertexArray);
        }
    }
}
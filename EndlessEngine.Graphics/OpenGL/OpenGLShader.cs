using System;
using System.Collections.Generic;
using System.Text;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLShader : IShader
    {
        private readonly uint id;
        private readonly IDictionary<string, int> uniforms;

        public OpenGLShader(string[] vertexSource, string[] fragmentSource)
        {
            uniforms = new Dictionary<string, int>();
            var vertexShader = CreateShader(vertexSource, ShaderType.VertexShader);
            var fragmentShader = CreateShader(fragmentSource, ShaderType.FragmentShader);

            id = Gl.CreateProgram();

            Gl.AttachShader(id, vertexShader);
            Gl.AttachShader(id, fragmentShader);
            Gl.LinkProgram(id);

            Gl.DetachShader(id, vertexShader);
            Gl.DetachShader(id, fragmentShader);
            Gl.DeleteShader(vertexShader);
            Gl.DeleteShader(fragmentShader);
        }

        public void Bind()
        {
            Gl.UseProgram(id);
        }

        public void Unbind()
        {
            Gl.UseProgram(0);
        }

        public void SetUniform(string name, float value)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform1(location, value);
        }

        public void SetUniform(string name, float v1, float v2)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, v1, v2);
        }

        public void SetUniform(string name, float v1, float v2, float v3)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, v1, v2, v3);
        }

        public void SetUniform(string name, float v1, float v2, float v3, float v4)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, v1, v2, v3, v4);
        }

        public void SetUniform(string name, int value)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform1(location, value);
        }

        public void SetUniform(string name, int v1, int v2)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, v1, v2);
        }

        public void SetUniform(string name, int v1, int v2, int v3)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, v1, v2, v3);
        }

        public void SetUniform(string name, int v1, int v2, int v3, int v4)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, v1, v2, v3, v4);
        }

        public void SetUniform(string name, MatrixUniformType type, bool transposed, float[] data)
        {
            var location = GetUniformLocation(name);
            switch (type)
            {
                case MatrixUniformType.Matrix2:
                    Gl.UniformMatrix2(location, transposed, data);
                    break;
                case MatrixUniformType.Matrix3:
                    Gl.UniformMatrix3(location, transposed, data);
                    break;
                case MatrixUniformType.Matrix4:
                    Gl.UniformMatrix4(location, transposed, data);
                    break;
                default:
                    Log.Instance.Error("Unknown ShaderDataType");
                    throw new ArgumentOutOfRangeException("Unknown ShaderDataType");
            }
        }

        private static uint CreateShader(string[] source, ShaderType type)
        {
            var id = Gl.CreateShader(type);
            Gl.ShaderSource(id, source);
            Gl.CompileShader(id);

            Gl.GetShader(id, ShaderParameterName.CompileStatus, out var compiled);
            if (compiled != 0)
                return id;

            // Not compiled!
            Gl.DeleteShader(id);

            const int logMaxLength = 1024;
            var infolog = new StringBuilder(1024);
            Gl.GetShaderInfoLog(id, logMaxLength, out _, infolog);

            throw new InvalidOperationException($"unable to compile shader: {infolog}");
        }

        private int GetUniformLocation(string name)
        {
            if (uniforms.ContainsKey(name))
                return uniforms[name];

            var location = Gl.GetUniformLocation(id, name);
            uniforms[name] = location;

            return location;
        }
    }
}
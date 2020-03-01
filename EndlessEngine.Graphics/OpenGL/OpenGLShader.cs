using System;
using System.Collections.Generic;
using System.Text;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLShader : IShader
    {
        private readonly uint _id;
        private IDictionary<string, int> _uniforms;

        public OpenGLShader(string[] vertexSource, string[] fragmentSource)
        {
            _uniforms = new Dictionary<string, int>();
            var vertexShader = CreateShader(vertexSource, ShaderType.VertexShader);
            var fragmentShader = CreateShader(fragmentSource, ShaderType.FragmentShader);
            
            _id = Gl.CreateProgram();

            Gl.AttachShader(_id, vertexShader);
            Gl.AttachShader(_id, fragmentShader);
            Gl.LinkProgram(_id);

            Gl.DetachShader(_id, vertexShader);
            Gl.DetachShader(_id, fragmentShader);
            Gl.DeleteShader(vertexShader);
            Gl.DeleteShader(fragmentShader);
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

        public void Bind() => 
            Gl.UseProgram(_id);

        public void Unbind() => 
            Gl.UseProgram(0);

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

        private int GetUniformLocation(string name)
        {
            if (_uniforms.ContainsKey(name))
                return _uniforms[name];

            var location = Gl.GetUniformLocation(_id, name);
            _uniforms[name] = location;

            return location;
        }
    }
}
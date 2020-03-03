using System;
using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLShaderLibrary : IShaderLibrary
    {
        private IDictionary<string, IShader> shaders;

        public OpenGLShaderLibrary()
        {
            shaders = new Dictionary<string, IShader>();
        }

        public void Add(IShader shader)
        {
            if (shader == null)
                throw new ArgumentNullException();

            if (shaders.ContainsKey(shader.Name))
                throw new Exception("Shader already exists");

            shaders[shader.Name] = shader;
        }

        public IShader Load(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            if (name == null || vertexShaderPath == null || fragmentShaderPath == null)
                throw new ArgumentNullException();

            var shader = new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
            Add(shader);
            return shader;
        }

        public IShader Get(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            return shaders[name];
        }
    }
}

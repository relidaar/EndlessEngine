using System;
using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLShaderLibrary : IShaderLibrary
    {
        private readonly IDictionary<string, IShader> _shaders;

        public OpenGLShaderLibrary()
        {
            _shaders = new Dictionary<string, IShader>();
        }

        public void Add(IShader shader)
        {
            if (shader == null)
                throw new ArgumentNullException();

            if (_shaders.ContainsKey(shader.Name))
                throw new Exception("Shader already exists");

            _shaders[shader.Name] = shader;
        }

        public IShader Load(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            if (string.IsNullOrWhiteSpace(name) || 
                string.IsNullOrWhiteSpace(vertexShaderPath) || 
                string.IsNullOrWhiteSpace(fragmentShaderPath))
                throw new ArgumentNullException();

            var shader = new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
            Add(shader);
            return shader;
        }

        public IShader Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();
            
            if (!_shaders.ContainsKey(name))
                throw new KeyNotFoundException();

            return _shaders[name];
        }
    }
}
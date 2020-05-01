// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 04-13-2020
// ***********************************************************************
// <copyright file="GraphicsSettings.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics
{
    /// <summary>
    /// Class Paths.
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// The resources path
        /// </summary>
        public const string ResourcesPath = "resources/";
        
        /// <summary>
        /// The shaders path
        /// </summary>
        public static readonly string ShadersPath = $"{ResourcesPath}shaders/";
        
        /// <summary>
        /// The graphics settings path
        /// </summary>
        public static readonly string GraphicsSettingsPath = $"{ResourcesPath}graphics.settings.json";
        
        /// <summary>
        /// The shader settings path
        /// </summary>
        public static readonly string ShaderSettingsPath = $"{ResourcesPath}shader.settings.json";
    }

    /// <summary>
    /// Struct GraphicsSettings
    /// </summary>
    public struct GraphicsSettings
    {
        /// <summary>
        /// The API version major
        /// </summary>
        public int ApiVersionMajor;
        
        /// <summary>
        /// The API version minor
        /// </summary>
        public int ApiVersionMinor;

        /// <summary>
        /// The maximized
        /// </summary>
        public bool Maximized;
        
        /// <summary>
        /// The resizable
        /// </summary>
        public bool Resizable;
        
        /// <summary>
        /// The double buffer
        /// </summary>
        public bool DoubleBuffer;
        
        /// <summary>
        /// The decorated
        /// </summary>
        public bool Decorated;
    }

    /// <summary>
    /// Struct ShaderSettings
    /// </summary>
    public struct ShaderSettings
    {
        /// <summary>
        /// The shader name
        /// </summary>
        public string ShaderName;
        
        /// <summary>
        /// The vertex shader filename
        /// </summary>
        public string VertexShaderFilename;
        
        /// <summary>
        /// The fragment shader filename
        /// </summary>
        public string FragmentShaderFilename;

        /// <summary>
        /// The vertices position
        /// </summary>
        public string VerticesPosition;
        
        /// <summary>
        /// The texture coordinates
        /// </summary>
        public string TextureCoordinates;

        /// <summary>
        /// The view projection uniform
        /// </summary>
        public string ViewProjectionUniform;
        
        /// <summary>
        /// The transform uniform
        /// </summary>
        public string TransformUniform;
        
        /// <summary>
        /// The texture uniform
        /// </summary>
        public string TextureUniform;
        
        /// <summary>
        /// The color uniform
        /// </summary>
        public string ColorUniform;
        
        /// <summary>
        /// The tiling factor uniform
        /// </summary>
        public string TilingFactorUniform;
    }
}
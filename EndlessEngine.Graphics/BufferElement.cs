// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="BufferElement.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using EndlessEngine.Core;

namespace EndlessEngine.Graphics
{
    /// <summary>
    /// Struct BufferElement
    /// </summary>
    public struct BufferElement
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name;
        
        /// <summary>
        /// The type
        /// </summary>
        public ShaderDataType Type;
        
        /// <summary>
        /// The size
        /// </summary>
        public int Size;
        
        /// <summary>
        /// The offset
        /// </summary>
        public int Offset;
        
        /// <summary>
        /// The normalized
        /// </summary>
        public bool Normalized;

        /// <summary>
        /// Initializes a new instance of the <see cref="BufferElement"/> struct.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="normalized">if set to <c>true</c> [normalized].</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BufferElement(ShaderDataType type, string name, bool normalized = false)
        {
            Name = name ?? throw new ArgumentNullException();
            Type = type;
            Size = ShaderDataTypeSize(type);
            Offset = 0;
            Normalized = normalized;
        }

        /// <summary>
        /// Gets the size of the shader data type.
        /// </summary>
        /// <param name="type">The shader type.</param>
        /// <returns>System.Int32.</returns>
        public static int ShaderDataTypeSize(ShaderDataType type)
        {
            switch (type)
            {
                case ShaderDataType.Int:
                case ShaderDataType.Float:
                    return 4;
                case ShaderDataType.Int2:
                case ShaderDataType.Float2:
                    return 4 * 2;
                case ShaderDataType.Int3:
                case ShaderDataType.Float3:
                    return 4 * 3;
                case ShaderDataType.Int4:
                case ShaderDataType.Float4:
                    return 4 * 4;
                case ShaderDataType.Mat3:
                    return 4 * 3 * 3;
                case ShaderDataType.Mat4:
                    return 4 * 4 * 4;
                case ShaderDataType.Bool:
                    return 1;
                default:
                    Log.Instance.Error("Unknown ShaderDataType");
                    return 0;
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount()
        {
            switch (Type)
            {
                case ShaderDataType.Bool:
                case ShaderDataType.Int:
                case ShaderDataType.Float:
                    return 1;
                case ShaderDataType.Int2:
                case ShaderDataType.Float2:
                    return 2;
                case ShaderDataType.Int3:
                case ShaderDataType.Float3:
                    return 3;
                case ShaderDataType.Int4:
                case ShaderDataType.Float4:
                    return 4;
                case ShaderDataType.Mat3:
                    return 3 * 3;
                case ShaderDataType.Mat4:
                    return 4 * 4;
                default:
                    Log.Instance.Error("Unknown ShaderDataType");
                    return 0;
            }
        }
    }

    /// <summary>
    /// Enum ShaderDataType
    /// </summary>
    public enum ShaderDataType
    {
        /// <summary>
        /// The float
        /// </summary>
        Float,
        /// <summary>
        /// The float2
        /// </summary>
        Float2,
        /// <summary>
        /// The float3
        /// </summary>
        Float3,
        /// <summary>
        /// The float4
        /// </summary>
        Float4,

        /// <summary>
        /// The mat3
        /// </summary>
        Mat3,
        /// <summary>
        /// The mat4
        /// </summary>
        Mat4,

        /// <summary>
        /// The int
        /// </summary>
        Int,
        /// <summary>
        /// The int2
        /// </summary>
        Int2,
        /// <summary>
        /// The int3
        /// </summary>
        Int3,
        /// <summary>
        /// The int4
        /// </summary>
        Int4,

        /// <summary>
        /// The bool
        /// </summary>
        Bool
    }
}
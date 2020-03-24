﻿using EndlessEngine.Core;

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
            Size = ShaderDataTypeSize(type);
            Offset = 0;
            Normalized = normalized;
        }

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

    public enum ShaderDataType
    {
        Float,
        Float2,
        Float3,
        Float4,

        Mat3,
        Mat4,

        Int,
        Int2,
        Int3,
        Int4,

        Bool
    }
}
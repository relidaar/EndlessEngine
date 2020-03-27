using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    public struct Vector4 : IEquatable<Vector4>
    {
        public static int Size => 4;

        public float X;
        public float Y;
        public float Z;
        public float W;

        public IEnumerable<float> Data => new[] {X, Y, Z, W};

        #region Constructors

        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4(in Vector4 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
            W = vector.W;
        }

        #endregion

        #region Operations

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Add(in Vector4 left, in Vector4 right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Add(in Vector4 left, float right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Subtract(in Vector4 left, in Vector4 right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Subtract(in Vector4 left, float right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Multiply(in Vector4 left, in Vector4 right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Multiply(in Vector4 left, float right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Divide(in Vector4 left, in Vector4 right)
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Divide(in Vector4 left, float right)
        {
            return left / right;
        }

        #endregion

        #region Operators

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator +(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z,
                left.W + right.W
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator +(in Vector4 left, float right)
        {
            return new Vector4(
                left.X + right,
                left.Y + right,
                left.Z + right,
                left.W + right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z,
                left.W - right.W
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, float right)
        {
            return new Vector4(
                left.X - right,
                left.Y - right,
                left.Z - right,
                left.W - right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X * right.X,
                left.Y * right.Y,
                left.Z * right.Z,
                left.W * right.W
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, float right)
        {
            return new Vector4(
                left.X * right,
                left.Y * right,
                left.Z * right,
                left.W * right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, in Vector4 right)
        {
            return new Vector4(
                left.X / right.X,
                left.Y / right.Y,
                left.Z / right.Z,
                left.W / right.W
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, float right)
        {
            return new Vector4(
                left.X / right,
                left.Y / right,
                left.Z / right,
                left.W / right
            );
        }

        #endregion

        #region IEquatable Implementation

        public bool Equals(Vector4 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
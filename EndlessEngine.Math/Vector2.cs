using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public static int Size => 2;

        public float X;
        public float Y;

        public IEnumerable<float> Data => new[] {X, Y};

        #region Constructors

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(in Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        #endregion

        #region Operations

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Add(in Vector2 left, in Vector2 right)
        {
            return left + right;
        }

        public static Vector2 Add(in Vector2 left, float right)
        {
            return left + right;
        }

        public static Vector2 Subtract(in Vector2 left, in Vector2 right)
        {
            return left - right;
        }

        public static Vector2 Subtract(in Vector2 left, float right)
        {
            return left - right;
        }

        public static Vector2 Multiply(in Vector2 left, in Vector2 right)
        {
            return left * right;
        }

        public static Vector2 Multiply(in Vector2 left, float right)
        {
            return left * right;
        }

        public static Vector2 Divide(in Vector2 left, in Vector2 right)
        {
            return left / right;
        }

        public static Vector2 Divide(in Vector2 left, float right)
        {
            return left / right;
        }

        #endregion

        #region Operators

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X + right.X,
                left.Y + right.Y
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(in Vector2 left, float right)
        {
            return new Vector2(
                left.X + right,
                left.Y + right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X - right.X,
                left.Y - right.Y
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(in Vector2 left, float right)
        {
            return new Vector2(
                left.X - right,
                left.Y - right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X * right.X,
                left.Y * right.Y
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(in Vector2 left, float right)
        {
            return new Vector2(
                left.X * right,
                left.Y * right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, in Vector2 right)
        {
            return new Vector2(
                left.X / right.X,
                left.Y / right.Y
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, float right)
        {
            return new Vector2(
                left.X / right,
                left.Y / right
            );
        }

        #endregion

        #region IEquatable Implementation

        public bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
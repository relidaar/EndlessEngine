using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EndlessEngine.Math
{
    public struct Vector3
    {
        public static int Size => 3;

        public float X;
        public float Y;
        public float Z;

        public IEnumerable<float> Data => new[] {X, Y, Z};

        #region Constructors

        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(in Vector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        #endregion

        #region Operations

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Add(in Vector3 left, in Vector3 right)
        {
            return left + right;
        }

        public static Vector3 Add(in Vector3 left, float right)
        {
            return left + right;
        }

        public static Vector3 Subtract(in Vector3 left, in Vector3 right)
        {
            return left - right;
        }

        public static Vector3 Subtract(in Vector3 left, float right)
        {
            return left - right;
        }

        public static Vector3 Multiply(in Vector3 left, in Vector3 right)
        {
            return left * right;
        }

        public static Vector3 Multiply(in Vector3 left, float right)
        {
            return left * right;
        }

        public static Vector3 Divide(in Vector3 left, in Vector3 right)
        {
            return left / right;
        }

        public static Vector3 Divide(in Vector3 left, float right)
        {
            return left / right;
        }

        #endregion

        #region Operators

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator +(in Vector3 left, in Vector3 right)
        {
            return new Vector3(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator +(in Vector3 left, float right)
        {
            return new Vector3(
                left.X + right,
                left.Y + right,
                left.Z + right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(in Vector3 left, in Vector3 right)
        {
            return new Vector3(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(in Vector3 left, float right)
        {
            return new Vector3(
                left.X - right,
                left.Y - right,
                left.Z - right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector3 left, in Vector3 right)
        {
            return new Vector3(
                left.X * right.X,
                left.Y * right.Y,
                left.Z * right.Z
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector3 left, float right)
        {
            return new Vector3(
                left.X * right,
                left.Y * right,
                left.Z * right
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(in Vector3 left, in Vector3 right)
        {
            return new Vector3(
                left.X / right.X,
                left.Y / right.Y,
                left.Z / right.Z
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(in Vector3 left, float right)
        {
            return new Vector3(
                left.X / right,
                left.Y / right,
                left.Z / right
            );
        }

        #endregion
    }
}
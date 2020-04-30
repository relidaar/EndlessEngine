using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;

namespace EndlessEngine.Graphics
{
    public class OrthographicCamera : ICamera
    {
        private Vector3 _position;
        private float _rotation;

        public OrthographicCamera(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException();
            
            ProjectionMatrix = Matrix4.Orthographic(0, width, 0, height);
            ViewMatrix = Matrix4.Identity;
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }

        public OrthographicCamera(float left, float right, float bottom, float top)
        {
            ProjectionMatrix = Matrix4.Orthographic(left, right, bottom, top);
            ViewMatrix = Matrix4.Identity;
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }

        public Matrix4 ProjectionMatrix { get; }
        public Matrix4 ViewMatrix { get; private set; }
        public Matrix4 ViewProjectionMatrix { get; private set; }

        public float Rotation
        {
            get => _rotation;
            set
            {
                RecalculateViewMatrix();
                _rotation = value;
            }
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                RecalculateViewMatrix();
                _position = value;
            }
        }

        private void RecalculateViewMatrix()
        {
            var transform = Matrix4.Translated(_position) * 
                            Matrix4.Rotated(_rotation, 0, 0, 1);

            ViewMatrix = transform.Invert();
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }
    }
}
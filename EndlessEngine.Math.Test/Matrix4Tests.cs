using OpenGL;
using Xunit;
    
namespace EndlessEngine.Math.Test
{
    public class Matrix4Tests 
    {
        #region Constructors
        
        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        
        public void CreateWithSingleValue(float value)
        {
            var result = new Matrix4(value).Matrix;
            var expected = new[,] { {value, value, value, value}, 
                {value, value, value, value}, 
                {value, value, value, value},
                {value, value, value, value}};

            Assert.Equal(expected , result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]
        
        public void CreateWithArray(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var result = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44).Matrix;
            var expected = new[,] {{m11, m12, m13, m14}, 
                {m21, m22, m23, m24}, 
                {m31, m32, m33, m34}, 
                {m41, m42, m43, m44} };
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void CreateWithMatrix(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var expected = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var result = new Matrix4(expected);
            
            Assert.Equal(expected.Matrix, result.Matrix );
        }
        
        #endregion
        
        #region Operations
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]
        
        public void TransposeMatrix4(float m11, float m12, float m13, float m14,
                                     float m21, float m22, float m23, float m24,
                                     float m31, float m32, float m33, float m34,
                                     float m41, float m42, float m43, float m44)
        { 
            var matrix = new Matrix4(m11, m12, m13, m14,
                                     m21, m22, m23, m24,
                                     m31, m32, m33, m34,
                                     m41, m42, m43, m44);
            var result = matrix.Transpose().Matrix;
            var expected = new[,] {{m11, m21, m31, m41}, {m12, m22, m32, m42}, {m13, m23, m33, m43}, {m14, m24, m34, m44}};;
            Assert.Equal(expected, result );
        }

        [Theory]
        [InlineData(2f,2f,1f,0f,1f,2f,2f,0f,2f,0f,0f,1f,1f,1f,2f,1f)]

        public void InvertMatrix(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{-2f, 3f, 2f, -2f}, {4f, -5f, -3f, 3f}, {-3f, 4f, 2f, -2f}, {4f, -6f, -3f, 4f}};
            var result = matrix.Invert().Matrix;
            
            Assert.Equal(expected, result);
            
        }
        

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void NegateMatrix4(float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44)
        {
            var matrix = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var result = matrix.Negate().Matrix;
            var expected = new[,] {{-m11, -m12, -m13, -m14}, {-m21, -m22, -m23, -m24}, {-m31, -m32, -m33, -m34}, {-m41, -m42, -m43, -m44}};;
            Assert.Equal(expected, result );
        }
        #endregion

        #region Operators
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void AddTwoMatrices(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 + m11, m12 + m12, m13 + m13, m14 + m14}, {m21 + m21, m22 + m22, m23 + m23, m24 + m24}, {m31 + m31, m32 + m32, m33 + m33, m34 + m34}, {m41 + m41, m42 + m42, m43 + m43, m44 + m44}};
            var result = (matrix1 + matrix2).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2f, -1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(0f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(-2f, 1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void AddMatrixAndNumber(float number,float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 + number, m12 + number, m13 + number, m14 + number},
                {m21 + number, m22 + number, m23 + number, m24 + number},
                {m31 + number, m32 + number, m33 + number, m34 + number},
                {m41 + number, m42 + number, m43 + number, m44 + number}};
            var result = (matrix + number).Matrix;
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void SubtractTwoMatrices(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 - m11, m12 - m12, m13 -m13, m14 - m14}, 
                {m21 - m21, m22 - m22, m23 - m23, m24 - m24}, 
                {m31 - m31, m32 - m32, m33 - m33, m34 - m34}, 
                {m41 - m41, m42 - m42, m43 - m43, m44 - m44}};
            var result = (matrix1 - matrix2).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(2f, -1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(0f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(-2f, 1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void SubtractTwoMatricesAndNumber(float number, float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 - number, m12 - number, m13 - number, m14 - number},
                {m21 - number, m22 - number, m23 - number, m24 - number},
                {m31 - number, m32 - number, m33 - number, m34 - number},
                {m41 - number, m42 - number, m43 - number, m44 - number}};
            var result = (matrix - number).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]
        
        public void MultiplyTwoMatrices(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 * m11 + m12 * m21 + m13 * m31 + m14 * m41, 
                                           m11 * m12 + m12 * m22 + m13 * m32 + m14 * m42,
                                           m11 * m13 + m12 * m23 + m13 * m33 + m14 * m43,
                                           m11 * m14 + m12 * m24 + m13 * m34 + m14 * m44},
                
                                          {m21 * m11 + m22 * m21 + m23 * m31 + m24 * m41, 
                                           m21 * m12 + m22 * m22 + m23 * m32 + m24 * m42,
                                           m21 * m13 + m22 * m23 + m23 * m33 + m24 * m43,
                                           m21 * m14 + m22 * m24 + m23 * m34 + m24 * m44},
                                          
                                          {m31 * m11 + m32 * m21 + m33 * m31 + m34 * m41, 
                                           m31 * m12 + m32 * m22 + m33 * m32 + m34 * m42,
                                           m31 * m13 + m32 * m23 + m33 * m33 + m34 * m43,
                                           m31 * m14 + m32 * m24 + m33 * m34 + m34 * m44},
                                          
                                          {m41 * m11 + m42 * m21 + m43 * m31 + m44 * m41, 
                                           m41 * m12 + m42 * m22 + m43 * m32 + m44 * m42,
                                           m41 * m13 + m42 * m23 + m43 * m33 + m44 * m43,
                                           m41 * m14 + m42 * m24 + m43 * m34 + m44 * m44}};
            var result = (matrix1 * matrix2).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(2f, -1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(0f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(-2f, 1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void MultiplyMatrixAndNumber(float number, float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 * number, m12 * number, m13 * number, m14 * number},
                {m21 * number, m22 * number, m23 * number, m24 * number},
                {m31 * number, m32 * number, m33 * number, m34 * number},
                {m41 * number, m42 * number, m43 * number, m44 * number}};
            var result = (matrix * number).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2f, -1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(0f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(-2f, 1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void DivideMatrixAndNumber(float number, float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var expected = new[,] {{m11 / number, m12 / number, m13 / number, m14 / number},
                {m21 / number, m22 / number, m23 / number, m24 / number},
                {m31 / number, m32 / number, m33 / number, m34 / number},
                {m41 / number, m42 / number, m43 / number, m44 / number}};
            var result = (matrix / number).Matrix;
            Assert.Equal(expected, result);
        }
        
        #endregion
        
        #region IEquatable Implementation
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void TwoMatricesAreEqual_True(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            Assert.True(matrix1 == matrix2);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void TwoMatricesAreEqual_False(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m31, m12, m13, m14,
                m21, m42, m44, m24,
                m11, m32, m33, m34,
                m41, m22, m43, m23);
            Assert.False(matrix1 == matrix2);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]
        
        public void TwoMatricesAreNotEqual_True(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            Assert.False(matrix1 != matrix2);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f,-1f, -2f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,0f, -1f, 0f, -3f, -5f, 2f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f,-1f, 0f, -3f, -5f, 2f, 1f, 0f)]
        [InlineData(1f, -1f, 0f, -1f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f,-1f, -2f, -3f, 2f)]

        public void TwoMatricesAreNotEqual_False(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            var matrix1 = new Matrix4(m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
            var matrix2 = new Matrix4(m14, m12, m13, m11,
                m21, m22, m33, m24,
                m31, m44, m23, m34,
                m41, m42, m43, m32);
            Assert.True(matrix1 != matrix2);
        }

        #endregion
            
    }
}
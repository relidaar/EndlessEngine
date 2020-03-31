using OpenGL;
using Xunit;
    
namespace EndlessEngine.Math.Test
{
    public class Matrix3Tests 
    {
        #region Constructors
        
        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        
        public void CreateWithSingleValue(float value)
        {
            var result = new Matrix3(value).Matrix;
            var expected = new[,] { {value, value, value}, {value, value, value}, {value, value, value} };

            Assert.Equal(expected , result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f,-1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f,-1f, -2f, -3f, -5f, 2f)]
        
        public void CreateWithArray(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var result = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33).Matrix;
            var expected = new[,] {{m11, m12, m13}, {m21, m22, m23}, {m31, m32, m33}};
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void CreateWithMatrix(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var expected = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var result = new Matrix3(expected);
            
            Assert.Equal(expected.Matrix, result.Matrix );
        }
        
        #endregion

        #region Operations
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]
        
        public void TransposeMatrix3(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        { 
            var matrix = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var result = matrix.Transpose().Matrix;
            var expected = new[,] {{m11, m21, m31}, {m12, m22, m32}, {m13, m23, m33}};;
            Assert.Equal(expected, result );
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void NegateMatrix3(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var result = matrix.Negate().Matrix;
            var expected = new[,] {{-m11, -m12, -m13}, {-m21, -m22, -m23}, {-m31, -m32, -m33}};;
            Assert.Equal(expected, result );
        }
        #endregion

        #region Operators
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void AddTwoMatrices(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 + m11, m12 + m12, m13 + m13}, {m21 + m21, m22 + m22, m23 + m23}, {m31 + m31, m32 + m32, m33 + m33}};
            var result = (matrix1 + matrix2).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0f, -1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(1f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(3f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(-1f, 1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void AddMatrixAndNumber(float number,float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 + number, m12 + number, m13 + number}, {m21 + number, m22 + number, m23 + number}, {m31 + number, m32 + number, m33 + number}};
            var result = (matrix + number).Matrix;
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void SubtractTwoMatrices(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 - m11, m12 - m12, m13 -m13}, {m21 - m21, m22 - m22, m23 - m23}, {m31 - m31, m32 - m32, m33 - m33}};
            var result = (matrix1 - matrix2).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(0f, -1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(1f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(3f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(-1f, 1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void SubtractTwoMatricesAndNumber(float number, float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 - number, m12 - number, m13 - number}, {m21 - number, m22 - number, m23 - number}, {m31 - number, m32 - number, m33 - number}};
            var result = (matrix - number).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]
        
        public void MultiplyTwoMatrices(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 * m11 + m12 * m21 + m13 * m31, 
                                           m11 * m12 + m12 * m22 + m13 * m32,
                                           m11 * m13 + m12 * m23 + m13 * m33}, 
                
                                          {m21 * m11 + m22 * m21 + m23 * m31,
                                           m21 * m12 + m22 * m22 + m23 * m32, 
                                           m21 * m13 + m22 * m23 + m23 * m33},

                                          {m31 * m11 + m32 * m21 + m33 * m31,
                                           m31 * m12 + m32 * m22 + m33 * m32,
                                           m31 * m13 + m32 * m23 + m33 * m33}};
            var result = (matrix1 * matrix2).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(0f, -1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(1f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(3f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(-1f, 1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void MultiplyMatrixAndNumber(float number, float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 * number, m12 * number, m13 * number}, {m21 * number, m22 * number, m23 * number},{m31 * number, m32 * number, m33 * number}};
            var result = (matrix * number).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0f, -1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(1f, 0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(3f, 1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(-1f, 1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void DivideMatrixAndNumber(float number, float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var expected = new[,] {{m11 / number, m12 / number, m13 / number}, {m21 / number, m22 / number, m23 / number}, {m31 / number, m32 / number, m33 / number}};
            var result = (matrix / number).Matrix;
            Assert.Equal(expected, result);
        }
        
        #endregion

        #region IEquatable Implementation
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void TwoMatricesAreEqual_True(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            Assert.True(matrix1 == matrix2);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void TwoMatricesAreEqual_False(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m33, m12, m13,
                m21, m32, m23,
                m31, m22, m11);
            Assert.False(matrix1 == matrix2);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]
        
        public void TwoMatricesAreNotEqual_True(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            Assert.False(matrix1 != matrix2);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f, 2f, 1f, 0f, -1f, 0f)]
        [InlineData(0f, 0f, -1f, 0f, -3f, -5f, 2f, 1f, 1f)]
        [InlineData(1f, 2f, -5f, 0f, 0f, -1f, 0f, -3f, -5f)]
        [InlineData(1f, -1f, 0f, -1f, -1f, -2f, -3f, -5f, 2f)]

        public void TwoMatricesAreNotEqual_False(float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            var matrix1 = new Matrix3(m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33);
            var matrix2 = new Matrix3(m33, m12, m13,
                m21, m32, m23,
                m31, m22, m11);
            Assert.True(matrix1 != matrix2);
        }

        #endregion


    }
}
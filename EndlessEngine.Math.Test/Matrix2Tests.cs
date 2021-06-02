using System.ComponentModel;
using OpenGL;
using Xunit;

namespace EndlessEngine.Math.Test
{
    public class Matrix2Tests
    {
        #region Constructors
        
        [Theory]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        public void CreateWithSingleValue(float value)
        {
            var result = new Matrix2(value).Matrix;
            var expected = new[,] { {value, value}, {value, value} };

            Assert.Equal(expected , result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]
        public void CreateWithFourValues(
            float m11, float m12,
            float m21, float m22)
        {
            var result = new Matrix2(m11, m12, 
                                     m21, m22).Matrix;
            var expected = new[,] {{m11, m12}, {m21, m22}};
            
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]
        public void CreateWithMatrix(float m11, float m12, 
                                     float m21, float m22)
        {
            var expected = new Matrix2(m11, m12, 
                                       m21, m22);
            var result = new Matrix2(expected);
            
            Assert.Equal(expected.Matrix, result.Matrix );
        }
        #endregion

        #region Operations

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]

        public void TransposeMatrix2(float m11, float m12, 
                                     float m21, float m22)
        { 
            var matrix = new Matrix2(m11, m12,
                m21, m22);
            var result = matrix.Transpose().Matrix;
            var expected = new[,] {{m11, m21}, {m12, m22}};;
            Assert.Equal(expected, result );
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]

        public void NegateMatrix2(float m11, float m12,
            float m21, float m22)
        {
            var matrix = new Matrix2(m11, m12,
                m21, m22);
            var result = matrix.Negate().Matrix;
            var expected = new[,] {{-m11, -m12}, {-m21, -m22}};;
            Assert.Equal(expected, result );
        }
        
        #endregion

        #region Operators

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]

        public void AddTwoMatrices(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m11, m12,
                m21, m22);
            var expected = new[,] {{m11 + m11, m12 + m12}, {m21 + m21, m22 + m22}};
            var result = (matrix1 + matrix2).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5f, -1f, -2f, -3f, -5f)]
        [InlineData(1f, 0f, 0f, -1f, 0f)]
        [InlineData(-2f, 1f, 2f, -5f, 0f)]
        [InlineData(0f, 1f, -1f, 0f, -1f)]

        public void AddMatrixAndNumber(float number, float m11, float m12, float m21, float m22)
        {
            var matrix = new Matrix2(m11, m12,
                                     m21, m22);
            var expected = new[,] {{m11 + number, m12 + number}, {m21 + number, m22 + number}};
            var result = (matrix + number).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]

        public void SubtractTwoMatrices(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m11, m12,
                m21, m22);
            var expected = new[,] {{m11 - m11, m12 - m12}, {m21 - m21, m22 - m22}};
            var result = (matrix1 - matrix2).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(5f, -1f, -2f, -3f, -5f)]
        [InlineData(1f, 0f, 0f, -1f, 0f)]
        [InlineData(-2f, 1f, 2f, -5f, 0f)]
        [InlineData(0f, 1f, -1f, 0f, -1f)]

        public void SubtractTwoMatricesAndNumber(float number, float m11, float m12, float m21, float m22)
        {
            var matrix = new Matrix2(m11, m12,
                m21, m22);
            var expected = new[,] {{m11 - number, m12 - number}, {m21 - number, m22 - number}};
            var result = (matrix - number).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]
        
        public void MultiplyTwoMatrices(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m11, m12,
                m21, m22);
            var expected = new[,] {{m11 * m11 + m12 * m21, m11 * m12 + m12 * m22}, 
                                          {m21 * m11 + m22 * m21, m21 * m12 + m22 * m22}};
            var result = (matrix1 * matrix2).Matrix;
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(5f, -1f, -2f, -3f, -5f)]
        [InlineData(1f, 0f, 0f, -1f, 0f)]
        [InlineData(-2f, 1f, 2f, -5f, 0f)]
        [InlineData(0f, 1f, -1f, 0f, -1f)]

        public void MultiplyMatrixAndNumber(float number, float m11, float m12, float m21, float m22)
        {
            var matrix = new Matrix2(m11, m12,
                m21, m22);
            var expected = new[,] {{m11 * number, m12 * number}, {m21 * number, m22 * number}};
            var result = (matrix * number).Matrix;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5f, -1f, -2f, -3f, -5f)]
        [InlineData(1f, 0f, 0f, -1f, 0f)]
        [InlineData(-2f, 1f, 2f, -5f, 0f)]
        [InlineData(0f, 1f, -1f, 0f, -1f)]

        public void DivideMatrixAndNumber(float number, float m11, float m12, float m21, float m22)
        {
            var matrix = new Matrix2(m11, m12,
                m21, m22);
            var expected = new[,] {{m11 / number, m12 / number}, {m21 / number, m22 / number}};
            var result = (matrix / number).Matrix;
            Assert.Equal(expected, result);
        }
        
        #endregion

        #region IEquatable Implementation

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 0f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]

        public void TwoMatricesAreEqual_True(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m11, m12,
                m21, m22);
            Assert.True(matrix1 == matrix2);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 2f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]

        public void TwoMatricesAreEqual_False(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m22, m12,
                m21, m11);
            Assert.False(matrix1 == matrix2);
        }
        
        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 2f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -1f, 0f, -1f)]
        
        public void TwoMatricesAreNotEqual_True(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m11, m12,
                m21, m22);
            Assert.False(matrix1 != matrix2);
        }

        [Theory]
        [InlineData(-1f, -2f, -3f, -5f)]
        [InlineData(0f, 0f, -1f, 2f)]
        [InlineData(1f, 2f, -5f, 0f)]
        [InlineData(1f, -2f, 0f, -1f)]

        public void TwoMatricesAreNotEqual_False(float m11, float m12, float m21, float m22)
        {
            var matrix1 = new Matrix2(m11, m12,
                m21, m22);
            var matrix2 = new Matrix2(m12, m22,
                m21, m11);
            Assert.True(matrix1 != matrix2);
        }

        #endregion
    }
}
using MoneyVeo.Web.Services.Imp;
using MoneyVeo.Web.Services.Services.Int;
using System;
using Xunit;

namespace MoneyVeo.Test.Services
{
    public class MatrixServiceTest
    {
        private readonly IMatrixService _matrixService;

        public MatrixServiceTest()
        {
            _matrixService = new MatrixService();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void GetRandomMatrixCheckType(int value)
        {
            var result = _matrixService.GetRandomMatrix(value);

            Assert.True(result.Matrix is int[,]);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void GetRandomMatrixWithCheckNull(int value)
        {
            var result = _matrixService.GetRandomMatrix(value);

            Assert.False(result.Matrix == null);
        }
    }
}

using FunctionApp.Models;
using System;
using Xunit;

namespace FunctionApp.Tests
{
    public class MathFunctionTests
    {
        [Theory]
        [InlineData(16, 2, 3, 5, 2, 4)]
        [InlineData(-4, -10, -35, 1, 1, 5)]
        public void LinearFunctionCalculationShouldReturnResult(
            int expectedResult, int x, int y, int a, int b, int c)
        {
            var function = new MathFunction(1);
            var actualResult = function.Calculate(x, y, a, b, c);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(56, 2, 3, 5, 2, 30)]
        [InlineData(115, -10, -35, 1, 1, 50)]
        public void QuadraticFunctionCalculationShouldReturnResult(
            int expectedResult, int x, int y, int a, int b, int c)
        {
            var function = new MathFunction(2);
            var actualResult = function.Calculate(x, y, a, b, c);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(158, 2, 3, 5, 2, 100)]
        [InlineData(425, -10, -35, 1, 1, 200)]
        public void CubicFunctionCalculationShouldReturnResult(
            int expectedResult, int x, int y, int a, int b, int c)
        {
            var function = new MathFunction(3);
            var actualResult = function.Calculate(x, y, a, b, c);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3134, 2, 3, 5, 2, 3000)]
        [InlineData(-27875, -10, -35, 1, 1, 5000)]
        public void BiquadraticFunctionCalculationShouldReturnResult(
            int expectedResult, int x, int y, int a, int b, int c)
        {
            var function = new MathFunction(4);
            var actualResult = function.Calculate(x, y, a, b, c);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(40322, 2, 3, 5, 2, 40000)]
        [InlineData(1410625, -10, -35, 1, 1, 10000)]
        public void PowerOfFiveFunctionCalculationShouldReturnResult(
            int expectedResult, int x, int y, int a, int b, int c)
        {
            var function = new MathFunction(5);
            var actualResult = function.Calculate(x, y, a, b, c);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 600)]
        [InlineData(4, 7000)]
        [InlineData(5, 5000)]
        public void FunctionCalculationShouldThrowWhenCoefficientCOutOfRange(int power, int c)
        {
            var function = new MathFunction(power);
            Action calculationAction = () => function.Calculate(1, 1, 1, 1, c);
            Assert.Throws<ArgumentOutOfRangeException>(calculationAction);
        }

        [Fact]
        public void FunctionInitializationShouwThrowWhenPowerLessThanOne()
        {
            Action initializationAction = () => new MathFunction(0);
            Assert.Throws<ArgumentException>(initializationAction);
        }
    }
}
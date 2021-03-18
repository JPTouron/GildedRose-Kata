using System;
using Xunit;

namespace GildedRose.Stock.Domain.Tests
{
    public class NormalQualityShould
    {
        [Theory]
        [InlineData(new object[] { 0 })]
        [InlineData(new object[] { 1 })]
        [InlineData(new object[] { 10 })]
        [InlineData(new object[] { int.MaxValue })]
        public void BeCreatedSuccesfully_AndHoldItsInitialValue(int initialValue)
        {
            var q = new NormalQuality(initialValue);

            Assert.Equal(initialValue, q.Value);
        }

        [Theory]
        [InlineData(new object[] { 10, 9 })]
        [InlineData(new object[] { 2, 1 })]
        [InlineData(new object[] { 1, 0 })]
        public void DecreaseItsQualityByTheExpectedValue(int initialValue, int expectedDecreasedValue)
        {
            var q = new NormalQuality(initialValue);

            q.Decrease();

            Assert.Equal(expectedDecreasedValue, q.Value);
        }

        [Theory]
        [InlineData(new object[] { -1 })]
        [InlineData(new object[] { int.MinValue })]
        public void Throw_WhenInitialValueIsNegative(int initialValue)
        {
            Assert.Throws<ArgumentException>(() => new NormalQuality(initialValue));
        }
    }
}
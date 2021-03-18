using GildedRose.Stock.Domain.ValueObjects;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.QualityValueTests
{
    public partial class QualityValueShould
    {
        [Theory]
        [InlineData(new object[] { 1, 1, 0 })]
        [InlineData(new object[] { 2, 2, 0 })]
        [InlineData(new object[] { 11, 3, 8 })]
        [InlineData(new object[] { 5, 2, 3 })]
        [InlineData(new object[] { 10, 1, 9 })]
        public void DecreaseByValue_WhenValidValueIsSet(int initialValue, int decreaseBy, int expectedValue)
        {
            var qv = new QualityValue(initialValue);
            qv.DecreaseBy(decreaseBy);

            Assert.Equal(qv.Value, expectedValue);
        }

        [Theory]
        [InlineData(new object[] { 10, 50, 0 })]
        [InlineData(new object[] { 10, 20, 0 })]
        [InlineData(new object[] { 0, 1, 0 })]
        public void SetValueToMin_WhenDecreaseByValueExceedsMaxAllowedValue(int initialValue, int decreaseBy, int expectedValue)
        {
            var qv = new QualityValue(initialValue);
            qv.DecreaseBy(decreaseBy);

            Assert.Equal(qv.Value, expectedValue);
        }

        [Theory]
        [InlineData(new object[] { -1 })]
        [InlineData(new object[] { int.MinValue })]
        [InlineData(new object[] { 51 })]
        [InlineData(new object[] { int.MaxValue })]
        public void Throw_WhenDecreaseByIsInvokedWithAnOutOfRangeValue(int decreaseBy)
        {
            var initialValue = 10;
            var qv = new QualityValue(initialValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => qv.DecreaseBy(decreaseBy));
        }
    }
}
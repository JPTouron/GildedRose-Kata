using GildedRose.Stock.Domain.ValueObjects;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.QualityValueTests
{
    public partial class QualityValueShould
    {
        [Theory]
        [InlineData(new object[] { 0, 0, 0 })]
        [InlineData(new object[] { 0, 2, 2 })]
        [InlineData(new object[] { 0, 50, 50 })]
        [InlineData(new object[] { 4, 2, 6 })]
        [InlineData(new object[] { 10, 20, 30 })]
        public void IncreaseByValue_WhenValidValueIsSet(int initialValue, int increaseBy, int expectedValue)
        {
            var qv = new QualityValue(initialValue);
            qv.IncreaseBy(increaseBy);

            Assert.Equal(qv.Value, expectedValue);
        }

        [Theory]
        [InlineData(new object[] { 51, 50 })]
        [InlineData(new object[] { int.MaxValue, 50 })]
        public void SetValueToMax_WhenIncreaseByValueExceedsMaxAllowedValue(int increaseBy, int expectedValue)
        {
            var initialValue = 0;
            var qv = new QualityValue(initialValue);
            qv.IncreaseBy(increaseBy);

            Assert.Equal(qv.Value, expectedValue);
        }

        [Theory]
        [InlineData(new object[] { -1 })]
        [InlineData(new object[] { int.MinValue })]
        public void Throw_WhenIncreaseByIsInvokedWithNegativeValue(int increaseBy)
        {
            var initialValue = 0;
            var qv = new QualityValue(initialValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => qv.IncreaseBy(increaseBy));
        }
    }
}
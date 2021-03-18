using GildedRose.Stock.Domain.ValueObjects;
using System;
using Xunit;


namespace GildedRose.Stock.Domain.QualityValueTests
{
    public partial class QualityValueShould
    {
        [Theory]
        [InlineData(new object[] { 0 })]
        [InlineData(new object[] { 10 })]
        public void BeCreatedWithInitialValueAndHoldIt(int initialValue)
        {
            var qv = new QualityValue(initialValue);
            Assert.Equal(qv.Value, initialValue);
        }

        [Theory]
        [InlineData(new object[] { 50 })]
        public void BeCreatedWithMaxInitialValueOfFifty(int initialValue)
        {
            var qv = new QualityValue(initialValue);
            Assert.Equal(qv.Value, initialValue);
        }

        [Theory]
        [InlineData(new object[] { -1 })]
        [InlineData(new object[] { int.MinValue })]
        public void ThrowException_WhenCreatedWithNegativeInitialValue(int initialValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new QualityValue(initialValue));
        }

        [Theory]
        [InlineData(new object[] { 100 })]
        [InlineData(new object[] { 51 })]
        [InlineData(new object[] { int.MaxValue })]
        public void ThrowException_WhenCreatedWithValueOverMaxOfFifty(int initialValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new QualityValue(initialValue));
        }
    }
}

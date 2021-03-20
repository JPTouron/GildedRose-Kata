using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.ConcreteQualities
{
    public class SulfurasQualityShould
    {
        [Theory]
        [InlineData(new object[] { 0 })]
        [InlineData(new object[] { 8 })]
        [InlineData(new object[] { 1 })]
        [InlineData(new object[] { 10 })]
        [InlineData(new object[] { 50 })]
        public void BeCreatedSuccesfully_AndHoldItsInitialQualityAndSellInValue(int initialQualityValue)
        {
            var q = CreateQuality(initialQualityValue);

            Assert.Equal(initialQualityValue, q.Value);
        }

        [Fact]
        internal void Throw_WhenQualityIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SulfurasQuality(null));
        }

        private static QualityValue CreateQualityValue(int initialQualityValue)
        {
            return new QualityValue(initialQualityValue);
        }

        private SulfurasQuality CreateQuality(int initialQualityValue)
        {
            var qv = CreateQualityValue(initialQualityValue);

            var q = new SulfurasQuality(qv);
            return q;
        }
    }
}
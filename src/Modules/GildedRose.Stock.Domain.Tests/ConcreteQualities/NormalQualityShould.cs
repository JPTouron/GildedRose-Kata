using GildedRose.Stock.Domain.ConcreteQualities.Base;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.ConcreteQualities
{
    public class NormalQualityShould : UpdatableQualitiesTestBase
    {
        [Theory]
        [InlineData(new object[] { 0, 2 })]
        [InlineData(new object[] { 8, int.MinValue })]
        [InlineData(new object[] { 1, int.MaxValue })]
        [InlineData(new object[] { 10, -4 })]
        [InlineData(new object[] { 50, 3 })]
        public void BeCreatedSuccesfully_AndHoldItsInitialQualityAndSellInValue(int initialQualityValue, int initialSellInValue)
        {
            var q = CreateQuality(initialQualityValue, initialSellInValue);

            Assert.Equal(initialQualityValue, q.Value);
        }

        [Theory]
        [InlineData(new object[] { 0, 0 })]
        [InlineData(new object[] { 1, 0 })]
        [InlineData(new object[] { 2, 1 })]
        [InlineData(new object[] { 10, 9 })]
        public void DecreaseItsQualityByOne_WhenQualityIsUpdated(int initialQualityValue, int expectedDecreasedQuality)
        {
            int initialSellInValue = GetRandomIntegerBetween(int.MinValue, int.MaxValue);

            var q = CreateQuality(initialQualityValue, initialSellInValue);

            q.UpdateQuality();

            Assert.Equal(expectedDecreasedQuality, q.Value);
        }

        internal override QualityBaseUpdatable InternalQualityCreation(QualityValue qv, SellInValue sv)
        {
            return new NormalQuality(qv, sv);
        }

        [Theory]
        [ClassData(typeof(DataProvider))]
        internal void Throw_WhenQualityOrSellInValueAreNull(QualityValue qualityValue, SellInValue sellInValue)
        {
            /*JP: this method is INTERNAL as the SellInValue class is internal
             * and we dont wanna make it public, if we hadn't used theory for this test, this would not be a problem
             */
            Assert.Throws<ArgumentNullException>(() => new NormalQuality(qualityValue, sellInValue));
        }
    }
}
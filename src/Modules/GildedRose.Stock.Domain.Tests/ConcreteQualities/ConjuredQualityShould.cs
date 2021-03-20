using GildedRose.Stock.Domain.ConcreteQualities.Base;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.ConcreteQualities
{
    public class ConjuredQualityShould : UpdatableQualitiesTestBase
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
        [InlineData(new object[] { 1, 0 })]
        [InlineData(new object[] { 2, 0 })]
        [InlineData(new object[] { 5, 3 })]
        [InlineData(new object[] { 13, 11 })]
        public void DecreaseItsQualityByTwo_WhenQualityIsUpdated(int initialQualityValue, int expectedDecreasedQuality)
        {
            int initialSellInValue = GetRandomIntegerBetween(int.MinValue, int.MaxValue);

            var q = CreateQuality(initialQualityValue, initialSellInValue);

            q.UpdateQuality();

            Assert.Equal(expectedDecreasedQuality, q.Value);
        }

        internal override BaseUpdatableQuality InternalQualityCreation(QualityValue qv, SellInValueUpdatable sv)
        {
            return new ConjuredQuality(qv, sv);
        }

        [Theory]
        [ClassData(typeof(DataProvider))]
        internal void Throw_WhenQualityOrSellInValueAreNull(QualityValue qualityValue, SellInValueUpdatable sellInValue)
        {
            Assert.Throws<ArgumentNullException>(() => new ConjuredQuality(qualityValue, sellInValue));
        }
    }
}
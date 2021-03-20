using GildedRose.Stock.Domain.ConcreteQualities.Base;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.ConcreteQualities
{
    public class AgedBrieQualityShould : UpdatableQualitiesTestBase
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
        [InlineData(new object[] { 1, 2 })]
        [InlineData(new object[] { 2, 3 })]
        [InlineData(new object[] { 10, 11 })]
        [InlineData(new object[] { 50, 50 })]
        public void IncreaseItsQualityByOne_WhenQualityIsUpdated(int initialQualityValue, int expectedDecreasedQuality)
        {
            int initialSellInValue = GetRandomIntegerBetween(int.MinValue, int.MaxValue);

            var q = CreateQuality(initialQualityValue, initialSellInValue);

            q.UpdateQuality();

            Assert.Equal(expectedDecreasedQuality, q.Value);
        }

        internal override BaseUpdatableQuality InternalQualityCreation(QualityValue qv, SellInValueUpdatable sv)
        {
            return new AgedBrieQuality(qv, sv);
        }

        [Theory]
        [ClassData(typeof(DataProvider))]
        internal void Throw_WhenQualityOrSellInValueAreNull(QualityValue qualityValue, SellInValueUpdatable sellInValue)
        {
            Assert.Throws<ArgumentNullException>(() => new AgedBrieQuality(qualityValue, sellInValue));
        }
    }
}
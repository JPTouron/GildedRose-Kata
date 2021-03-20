using GildedRose.Stock.Domain.ConcreteQualities.Base;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using System;
using Xunit;

namespace GildedRose.Stock.Domain.ConcreteQualities
{
    public class BackstageQualityShould : UpdatableQualitiesTestBase
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
        [InlineData(new object[] { 10, 20, 11 })]
        [InlineData(new object[] { 10, 10, 12 })]
        [InlineData(new object[] { 20, 6, 22 })]
        [InlineData(new object[] { 20, 5, 23 })]
        [InlineData(new object[] { 10, 1, 13 })]
        [InlineData(new object[] { 10, 0, 0 })]
        [InlineData(new object[] { 50, 0, 0 })]

        public void UpdateQualityDependingOnHowCloseTheConcertDateIs(int initialQualityValue, int initialSellInValue, int expectedUpdatedQualityValue)
        {
            var q = CreateQuality(initialQualityValue, initialSellInValue);

            q.UpdateQuality();

            Assert.Equal(expectedUpdatedQualityValue, q.Value);
        }

        internal override QualityBaseUpdatable InternalQualityCreation(QualityValue qv, SellInValue sv)
        {
            return new BackstagePassQuality(qv, sv);
        }

        [Theory]
        [ClassData(typeof(DataProvider))]
        internal void Throw_WhenQualityOrSellInValueAreNull(QualityValue qualityValue, SellInValue sellInValue)
        {
            Assert.Throws<ArgumentNullException>(() => new BackstagePassQuality(qualityValue, sellInValue));
        }
    }
}
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Stock.Domain.ConcreteQualities
{
    public class AgedBrieQualityShould
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
        public void IncreaseItsQualityByOne_WhenQualityIsUpdated(int initialQualityValue, int expectedDecreasedQuality)
        {
            int initialSellInValue = GetRandomIntegerBetween(int.MinValue, int.MaxValue);

            var q = CreateQuality(initialQualityValue, initialSellInValue);

            q.UpdateQuality();

            Assert.Equal(expectedDecreasedQuality, q.Value);
        }

        [Theory]
        [ClassData(typeof(DataProvider))]
        internal void Throw_WhenQualityOrSellInValueAreNull(QualityValue qualityValue, SellInValue sellInValue)
        {
            Assert.Throws<ArgumentNullException>(() => new AgedBrieQuality(qualityValue, sellInValue));
        }

        private static QualityValue CreateQualityValue(int initialQualityValue)
        {
            return new QualityValue(initialQualityValue);
        }

        private static SellInValue CreateSellInValue(int initialSellInValue)
        {
            return new SellInValue(initialSellInValue);
        }

        private AgedBrieQuality CreateQuality(int initialQualityValue, int initialSellInValue)
        {
            var qv = CreateQualityValue(initialQualityValue);
            var sv = CreateSellInValue(initialSellInValue);

            var q = new AgedBrieQuality(qv, sv);
            return q;
        }

        private int GetRandomIntegerBetween(int min, int max)
        {
            var r = new Random();
            int initialSellInValue = r.Next(min, max);

            return initialSellInValue;
        }

        private class DataProvider : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var r = new Random();
                var qv = r.Next(0, 50);
                var sv = r.Next();
                yield return new object[] { CreateQualityValue(qv), null };
                yield return new object[] { null, CreateSellInValue(sv) };
                yield return new object[] { null, null };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GildedRose.Stock.Domain.ConcreteQualities.Base
{
    public abstract class UpdatableQualitiesTestBase
    {
        internal BaseUpdatableQuality CreateQuality(int initialQualityValue, int initialSellInValue)
        {
            var qv = CreateQualityValue(initialQualityValue);
            var sv = CreateSellInValue(initialSellInValue);

            var q = InternalQualityCreation(qv, sv);
            return q;
        }

        internal abstract BaseUpdatableQuality InternalQualityCreation(QualityValue qv, SellInValueUpdatable sv);

        protected int GetRandomIntegerBetween(int min, int max)
        {
            var r = new Random();
            int initialSellInValue = r.Next(min, max);

            return initialSellInValue;
        }

        private static QualityValue CreateQualityValue(int initialQualityValue)
        {
            return new QualityValue(initialQualityValue);
        }

        private static SellInValueUpdatable CreateSellInValue(int initialSellInValue)
        {
            return new SellInValueUpdatable(initialSellInValue);
        }

        protected class DataProvider : IEnumerable<object[]>
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
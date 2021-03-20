using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.Qualities.Contracts;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Domain.Qualities.Base
{
    public abstract class BaseUpdatableQuality : IQuality, IQualityUpdatable
    {
        protected readonly QualityValue currentQuality;
        protected readonly SellInValueUpdatable currentSellIn;

        protected BaseUpdatableQuality(QualityValue initialQuality, SellInValueUpdatable initialSellIn)
        {
            Guard.Against.Null(initialQuality, nameof(initialQuality));
            Guard.Against.Null(initialSellIn, nameof(initialSellIn));

            currentQuality = initialQuality;
            currentSellIn = initialSellIn;
        }

        public int Value => currentQuality.Value;

        public void UpdateQuality()
        {
            UpdateQualityInternal();
        }

        protected abstract void UpdateQualityInternal();
    }
}
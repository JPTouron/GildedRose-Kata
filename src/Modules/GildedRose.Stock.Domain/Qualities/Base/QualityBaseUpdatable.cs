using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.Qualities.Contracts;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities.Base
{
    internal abstract class QualityBaseUpdatable : IQuality, IQualityUpdatable
    {
        protected readonly SellInValue curentSellIn;
        protected readonly QualityValue currentQuality;

        protected QualityBaseUpdatable(QualityValue initialQuality, SellInValue initialSellIn)
        {
            Guard.Against.Null(initialQuality, nameof(initialQuality));
            Guard.Against.Null(initialSellIn, nameof(initialSellIn));

            currentQuality = initialQuality;
            curentSellIn = initialSellIn;
        }

        public int Value => currentQuality.Value;

        public void UpdateQuality()
        {
            UpdateQualityInternal();
        }

        protected abstract void UpdateQualityInternal();

    }
}
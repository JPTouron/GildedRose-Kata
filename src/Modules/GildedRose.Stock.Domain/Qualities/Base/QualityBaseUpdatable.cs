using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities.Base
{
    internal abstract class QualityBaseUpdatable
    {
        protected readonly SellInValue curentSellIn;
        protected readonly QualityValue currentQuality;

        protected QualityBaseUpdatable(QualityValue initialQuality, SellInValue initialSellIn)
        {
            Guard.Against.Null(initialQuality, nameof(initialQuality));
            Guard.Against.Null(initialQuality, nameof(initialSellIn));
            
            currentQuality = initialQuality;
            curentSellIn = initialSellIn;
        }
    }
}
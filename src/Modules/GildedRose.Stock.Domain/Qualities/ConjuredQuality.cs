using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities
{
    internal class ConjuredQuality : QualityBaseUpdatable
    {
        private const int qualityIncreaseRate = 2;

        public ConjuredQuality(QualityValue initialQuality, SellInValue initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.DecreaseBy(qualityIncreaseRate);
        }
    }
}
using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities
{
    internal class AgedBrieQuality : QualityBaseUpdatable
    {
        private const int qualityIncreaseRate = 1;

        public AgedBrieQuality(QualityValue initialQuality, SellInValue initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.IncreaseBy(qualityIncreaseRate);
        }
    }
}
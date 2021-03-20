using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities
{
    internal class AgedBrieQuality : QualityBaseUpdatable
    {
        public AgedBrieQuality(QualityValue initialQuality, SellInValue initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.IncreaseBy(1);
        }
    }
}
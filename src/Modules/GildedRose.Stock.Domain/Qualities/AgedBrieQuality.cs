using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Domain.Qualities
{
    public class AgedBrieQuality : BaseUpdatableQuality
    {
        private const int qualityIncreaseRate = 1;

        public AgedBrieQuality(QualityValue initialQuality, SellInValueUpdatable initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.IncreaseBy(qualityIncreaseRate);
        }
    }
}
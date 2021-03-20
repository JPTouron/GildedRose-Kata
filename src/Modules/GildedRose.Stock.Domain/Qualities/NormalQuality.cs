using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Domain.Qualities
{
    public class NormalQuality : BaseUpdatableQuality
    {
        private const int qualityDecreaseRate = 1;

        public NormalQuality(QualityValue initialQuality, SellInValueUpdatable initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.DecreaseBy(qualityDecreaseRate);
        }
    }
}
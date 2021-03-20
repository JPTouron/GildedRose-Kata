using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Domain.Qualities
{
    public class ConjuredQuality : BaseUpdatableQuality
    {
        private const int qualityIncreaseRate = 2;

        public ConjuredQuality(QualityValue initialQuality, SellInValueUpdatable initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.DecreaseBy(qualityIncreaseRate);
        }
    }
}
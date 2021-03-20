using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.Qualities.Base.Contracts;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities
{
    internal class NormalQuality : QualityBaseUpdatable
    {
        public NormalQuality(QualityValue initialQuality, SellInValue initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        protected override void UpdateQualityInternal()
        {
            currentQuality.DecreaseBy(1);
        }
    }
}
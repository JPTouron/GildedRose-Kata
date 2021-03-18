using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.Qualities.Contracts;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities
{
    internal class NormalQuality : QualityBaseUpdatable, IQuality, IQualityUpdatable
    {
        public NormalQuality(QualityValue initialQuality, SellInValue initialSellIn) : base(initialQuality, initialSellIn)
        {
        }

        public int Value => currentQuality.Value;

        public void UpdateQuality()
        {
            currentQuality.DecreaseBy(1);
        }
    }
}
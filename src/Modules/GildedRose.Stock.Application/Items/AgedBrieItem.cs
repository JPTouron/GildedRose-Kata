using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Application.Factory
{
    internal class AgedBrieItem : BaseUpdatableItem<AgedBrieQuality>, IUpdatableItemAdapter
    {
        public AgedBrieItem(Item item) : base(item)
        {
        }

        protected override AgedBrieQuality CreateQualityForItem(int initialQuality, int initialSellin)
        {
            var newQuality = new AgedBrieQuality(new QualityValue(initialQuality), new SellInValueUpdatable(initialSellin));
            return newQuality;
        }
    }
}
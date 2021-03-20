using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Application.Factory
{
    internal class NormalItem : BaseUpdatableItem<NormalQuality>, IUpdatableItemAdapter
    {
        public NormalItem(Item item) : base(item)
        {
        }

        protected override NormalQuality CreateQualityForItem(int initialQuality, int initialSellin)
        {
            var newQuality = new NormalQuality(new QualityValue(initialQuality), new SellInValueUpdatable(initialSellin));
            return newQuality;
        }
    }
}
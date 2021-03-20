using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Application.Factory
{
    internal class ConjuredItem : BaseUpdatableItem<ConjuredQuality>, IUpdatableItemAdapter
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

        protected override ConjuredQuality CreateQualityForItem(int initialQuality, int initialSellin)
        {
            var newQuality = new ConjuredQuality(new QualityValue(initialQuality), new SellInValueUpdatable(initialSellin));
            return newQuality;
        }
    }
}
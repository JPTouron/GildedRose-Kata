using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;

namespace GildedRose.Stock.Application.Factory
{
    internal class BackstagePassItem : BaseUpdatableItem<BackstagePassQuality>, IUpdatableItemAdapter
    {
        public BackstagePassItem(Item item) : base(item)
        {
        }

        protected override BackstagePassQuality CreateQualityForItem(int initialQuality, int initialSellin)
        {
            var newQuality = new BackstagePassQuality(new QualityValue(initialQuality), new SellInValueUpdatable(initialSellin));
            return newQuality;
        }
    }
}
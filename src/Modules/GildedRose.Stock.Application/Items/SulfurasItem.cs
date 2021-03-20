using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Application.Factory
{
    internal class SulfurasItem : IItemAdapter, IUpdatableItemAdapter
    {
        private Item item;
        private SulfurasQuality quality;

        public SulfurasItem(Item item)
        {
            Guard.Against.Null(item, nameof(item));

            this.item = item;

            quality = CreateQualityForItem(item.Quality);
        }

        public string Name
        {
            get => item.Name;
            set => item.Name = value;
        }

        public int Quality => quality.Value;

        public int SellIn
        {
            get => item.SellIn;
        }

        public void DecreaseSellInByOne()
        {
            //nothing to do here! :-)
        }

        private SulfurasQuality CreateQualityForItem(int initialQuality)
        {
            return new SulfurasQuality(new QualityValue(initialQuality));
        }
    }
}
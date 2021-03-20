using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Domain.Qualities.Base;

namespace GildedRose.Stock.Application.Factory
{
    internal abstract class BaseUpdatableItem<SulfurasQuality> : IItemAdapter where SulfurasQuality : BaseUpdatableQuality
    {
        private const int sellInDecreaseRate = 1;
        private Item item;
        private SulfurasQuality quality;

        protected BaseUpdatableItem(Item item)
        {
            Guard.Against.Null(item, nameof(item));

            this.item = item;

            quality = CreateQualityForItem(item.Quality, item.SellIn);
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
            item.SellIn--;
            quality.UpdateQuality();
            item.Quality = quality.Value;
        }

        protected abstract SulfurasQuality CreateQualityForItem(int initialQuality, int initialSellin);
    }
}
using GildedRose.Stock.Domain.Items;
using System;

namespace GildedRose.Stock.Application.Factory
{
    public class UpdatableItemsFactory : IUpdatableItemsFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage";
        private const string Conjured = "Conjured";
        private const string Sulfuras = "Sulfuras";

        public IUpdatableItemAdapter CreateItem(Item item)
        {
            if (IsItemOfType(AgedBrie, item))
                return new AgedBrieItem(item);
            if (IsItemOfType(BackstagePass, item))
                return new BackstagePassItem(item);

            if (IsItemOfType(Conjured, item))
                return new ConjuredItem(item);

            if (IsItemOfType(Sulfuras, item))
                return new SulfurasItem(item);

            return new NormalItem(item);
        }

        private bool IsItemOfType(string namePart, Item item)
        {
            return item.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
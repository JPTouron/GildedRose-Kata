using GildedRose.Stock.Domain.Items;

namespace GildedRose.Stock.Application.Factory
{
    public interface IUpdatableItemsFactory
    {
        IUpdatableItemAdapter CreateItem(Item item);
    }
}
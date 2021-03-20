using GildedRose.Stock.Domain.Items.Base;

namespace GildedRose.Stock.Application.Factory
{
    public interface IItemsFactory
    {
        IItem CreateItem(Item item);
    }
}
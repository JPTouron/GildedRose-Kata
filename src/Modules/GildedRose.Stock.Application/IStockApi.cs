using GildedRose.Stock.Application.Factory;
using GildedRose.Stock.Application.Ports;
using GildedRose.Stock.Domain.Items;
using System.Collections.Generic;

namespace GildedRose.Stock.Application
{
    public interface IStockApi
    {
        IReadOnlyCollection<Item> GetAllAvailableItems();

        void UpdateQualityOfItems(IReadOnlyCollection<Item> items);
    }

    public class StockApi : IStockApi
    {
        private readonly IUpdatableItemsFactory factory;
        private readonly IItemsRepository repo;

        public StockApi(IItemsRepository repo, IUpdatableItemsFactory factory)
        {
            this.repo = repo;
            this.factory = factory;
        }

        public IReadOnlyCollection<Item> GetAllAvailableItems()
        {
            return repo.GetItems();
        }

        public void UpdateQualityOfItems(IReadOnlyCollection<Item> items)
        {
            foreach (var item in items)
            {
                var decoratedItem = factory.CreateItem(item);
                decoratedItem.DecreaseSellInByOne();
            }
        }
    }
}
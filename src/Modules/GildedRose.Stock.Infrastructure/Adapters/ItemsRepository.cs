using GildedRose.Stock.Application.Ports;
using GildedRose.Stock.Domain;
using System;
using System.Collections.Generic;

namespace GildedRose.Stock.Infrastructure.Adapters
{
    internal sealed class ItemsRepository : IItemsRepository
    {
        public IReadOnlyCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
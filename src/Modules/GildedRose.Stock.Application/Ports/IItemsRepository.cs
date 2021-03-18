﻿using GildedRose.Stock.Domain.Items.Base;
using System.Collections.Generic;

namespace GildedRose.Stock.Application.Ports
{
    public interface IItemsRepository
    {
        IReadOnlyCollection<Item> GetItems();
    }
}
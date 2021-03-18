using GildedRose.Stock.Domain.Items.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Stock.Application.Factory
{
    public interface IItemsFactory
    {

        IItem CreateItem(Item item);
    }
}

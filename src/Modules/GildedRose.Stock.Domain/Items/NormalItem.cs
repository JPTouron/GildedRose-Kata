using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.Items.Base;
using GildedRose.Stock.Domain.Qualities;
using GildedRose.Stock.Domain.Qualities.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Stock.Domain.Items
{
    //JP: CHECK THE PROJECT FILE TO FIND THAT I'M USING INTERNALSVISIBLETO TO PERFORM TDD ON INTERNAL MEMBERS OF THIS PACKAGE
    internal class NormalItem : IItem
    {

        public NormalItem(Item item, IDecreasableSellInValue sellInValue, NormalQuality normalQuality )
        {

            Guard.Against.Null(item, nameof(item));
            Guard.Against.Null(sellInValue, nameof(sellInValue));
            Guard.Against.Null(normalQuality, nameof(normalQuality));
        }

        public string Name => throw new NotImplementedException();

        public int Quality => throw new NotImplementedException();

        public int SellIn => throw new NotImplementedException();
    }
}

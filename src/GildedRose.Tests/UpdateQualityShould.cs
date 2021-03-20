//using FluentAssertions;
using GildedRose.Console;
using GildedRose.Stock.Domain.Items;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// this class will be for now our control test, meaning that should fail when we mess up until we change the model
    /// </summary>
    public class UpdateQualityShould
    {
        private Program sut;

        [Fact]
        public void DecreaseQualityOfConjuredItemByTwo_AndDecreaseSellInByOne()
        {
            const string conjured = "Conjured Mana Cake";

            sut = new Program()
            {
                Items = new List<Item>
                {
                     new Item { Name = conjured, SellIn = 3, Quality = 6}
                }
            };

            sut.UpdateQuality();

            AssertThis(conjured, 2, 4);
        }

        [Fact]
        public void UpdateQualityAccordingToSpecs_AndDecreaseSellInByOne()
        {
            const string dexterityVest = "+5 Dexterity Vest";
            const string agedBrie = "Aged Brie";
            const string elixir = "Elixir of the Mongoose";
            const string sulfuras = "Sulfuras, Hand of Ragnaros";
            const string backstagePass = "Backstage passes to a TAFKAL80ETC concert";
            const string conjured = "Conjured Mana Cake";

            sut = new Program();

            sut.UpdateQuality();

            AssertThis(dexterityVest, 9, 19);
            AssertThis(agedBrie, 1, 1);
            AssertThis(elixir, 4, 6);
            AssertThis(sulfuras, 0, 50);
            AssertThis(backstagePass, 14, 21);
            AssertThis(conjured, 2, 4);
        }

        private void AssertThis(string itemName, int expectedSellIn, int expectedQuality)
        {
            Assert.Equal(Item(itemName).SellIn, expectedSellIn);
            Assert.Equal(Item(itemName).Quality, expectedQuality);
        }

        private Item Item(string dexterityVest)
        {
            return sut.Items.First(x => x.Name == dexterityVest);
        }
    }
}
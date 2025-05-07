using Xunit;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void WhenUpdating_ShouldPerformAsExpected()
        {
            Console.Program.DoMain();

            var actualOutput = Console.Program.ConsoleOutput.ToString();

            var expectedOutput = @"OMGHAI!
Stored Items Current Status:
Name: '+5 Dexterity Vest', Quality: '20', SellIn: '10'
Name: 'Aged Brie', Quality: '0', SellIn: '2'
Name: 'Elixir of the Mongoose', Quality: '7', SellIn: '5'
Name: 'Sulfuras, Hand of Ragnaros', Quality: '80', SellIn: '0'
Name: 'Backstage passes to a TAFKAL80ETC concert', Quality: '20', SellIn: '15'
Name: 'Conjured Mana Cake', Quality: '6', SellIn: '3'

=========================================
Items have been updated
=========================================

Stored Items Status After Update:
Name: '+5 Dexterity Vest', Quality: '19', SellIn: '9'
Name: 'Aged Brie', Quality: '1', SellIn: '1'
Name: 'Elixir of the Mongoose', Quality: '6', SellIn: '4'
Name: 'Sulfuras, Hand of Ragnaros', Quality: '80', SellIn: '0'
Name: 'Backstage passes to a TAFKAL80ETC concert', Quality: '21', SellIn: '14'
Name: 'Conjured Mana Cake', Quality: '5', SellIn: '2'
";

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
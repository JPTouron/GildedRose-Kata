using GildedRose.Stock.Domain.ValueObjects;
using Xunit;

namespace GildedRose.Stock.Domain.QualityValueTests
{
    public class SellInValueShould_DecreaseValue
    {
        [Theory]
        [InlineData(new object[] { 1, 0 })]
        [InlineData(new object[] { 2, 1 })]
        [InlineData(new object[] { 9, 8 })]
        [InlineData(new object[] { 4, 3 })]
        [InlineData(new object[] { 10, 9 })]
        public void DecreaseValueByOne(int initialValue, int expectedValue)
        {
            var sv = new SellInValue(initialValue);
            sv.DecreaseValue();

            Assert.Equal(sv.Value, expectedValue);
        }
    }
}
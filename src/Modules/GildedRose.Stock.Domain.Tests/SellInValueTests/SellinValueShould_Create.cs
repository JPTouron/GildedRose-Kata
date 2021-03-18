using GildedRose.Stock.Domain.ValueObjects;
using Xunit;

namespace GildedRose.Stock.Domain.SellInValueTests
{
    public class SellinValueShould_Create
    {
        [Theory]
        [InlineData(new object[] { 0 })]
        [InlineData(new object[] { 10 })]
        [InlineData(new object[] { int.MaxValue })]
        [InlineData(new object[] { int.MinValue })]
        public void BeCreatedWithInitialValueAndHoldIt(int initialValue)
        {
            var sv = new SellInValue(initialValue);
            Assert.Equal(sv.Value, initialValue);
        }
    }
}
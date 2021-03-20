using GildedRose.Stock.Domain.ValueObjects.SellIn;
using Xunit;

namespace GildedRose.Stock.Domain.QualityValueTests
{
    public class SellInValueUpdatableShould
    {
        [Theory]
        [InlineData(new object[] { 0 })]
        [InlineData(new object[] { 10 })]
        [InlineData(new object[] { int.MaxValue })]
        [InlineData(new object[] { int.MinValue })]
        public void BeCreatedWithInitialValueAndHoldIt(int initialValue)
        {
            var sv = new SellInValueUpdatable(initialValue);
            Assert.Equal(sv.Value, initialValue);
        }

        [Theory]
        [InlineData(new object[] { 1, 0 })]
        [InlineData(new object[] { 2, 1 })]
        [InlineData(new object[] { 9, 8 })]
        [InlineData(new object[] { 4, 3 })]
        [InlineData(new object[] { 10, 9 })]
        public void DecreaseValueByOne(int initialValue, int expectedValue)
        {
            var sv = new SellInValueUpdatable(initialValue);
            sv.DecreaseValue();

            Assert.Equal(sv.Value, expectedValue);
        }
    }
}
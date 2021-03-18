using GildedRose.Stock.Domain.Qualities.Contracts;

namespace GildedRose.Stock.Domain.ValueObjects
{
    internal class SellInValue : ISellInValue, IDecreasableSellInValue
    {
        private const int decreaseBy = 1;
        private int currentValue;

        public SellInValue(int initialValue)
        {
            currentValue = initialValue;
        }

        public int Value => currentValue;

        public void DecreaseValue()
        {
            currentValue -= decreaseBy;
        }
    }
}
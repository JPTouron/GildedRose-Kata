using GildedRose.Stock.Domain.ValueObjects.SellIn.Base;

namespace GildedRose.Stock.Domain.ValueObjects.SellIn
{
    public class SellInValueUpdatable : SellInValueBase
    {
        private const int decreaseBy = 1;

        public SellInValueUpdatable(int initialValue) : base(initialValue)
        {
        }

        public void DecreaseValue()
        {
            currentValue -= decreaseBy;
        }
    }
}
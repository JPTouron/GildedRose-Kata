namespace GildedRose.Stock.Domain.ValueObjects.SellIn.Base
{
    public abstract class SellInValueBase
    {
        protected int currentValue;

        public SellInValueBase(int initialValue)
        {
            currentValue = initialValue;
        }

        public int Value => currentValue;
    }
}
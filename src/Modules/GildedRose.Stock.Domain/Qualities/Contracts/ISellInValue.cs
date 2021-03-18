namespace GildedRose.Stock.Domain.Qualities.Contracts
{
    public interface IDecreasableSellInValue
    {
        void DecreaseValue();
    }

    public interface ISellInValue
    {
        int Value { get; }
    }
}
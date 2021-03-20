namespace GildedRose.Stock.Domain.Qualities.Base.Contracts
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
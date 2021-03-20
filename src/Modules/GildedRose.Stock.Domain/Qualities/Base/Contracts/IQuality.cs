namespace GildedRose.Stock.Domain.Qualities.Base.Contracts
{
    public interface IQuality
    {
        int Value { get; }
    }

    public interface IQualityUpdatable
    {
        void UpdateQuality();
    }
}
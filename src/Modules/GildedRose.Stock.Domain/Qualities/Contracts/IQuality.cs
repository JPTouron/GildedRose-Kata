namespace GildedRose.Stock.Domain.Qualities.Contracts
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
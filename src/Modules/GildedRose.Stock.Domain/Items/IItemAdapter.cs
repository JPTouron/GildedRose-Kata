namespace GildedRose.Stock.Domain.Items
{
    public interface IItemAdapter
    {
        string Name { get; set; }

        int Quality { get; }

        int SellIn { get; }
    }

    public interface IUpdatableItemAdapter
    {
        void DecreaseSellInByOne();
    }
}
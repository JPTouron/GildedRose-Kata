namespace GildedRose.Stock.Domain.Items.Base
{
    public interface IItem
    {
        string Name { get; }

        int Quality { get; }

        int SellIn { get; }
    }
}
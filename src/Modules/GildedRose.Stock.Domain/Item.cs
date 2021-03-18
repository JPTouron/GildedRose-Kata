namespace GildedRose.Stock.Domain
{
    public interface IItem
    {
        string Name { get; }

        int Quality { get; }

        int SellIn { get; }
    }

    //JP: create items wrapping item as to not need to change the item class as per specs
    public class Item
    {
        public string Name { get; set; }

        public int Quality { get; set; }

        public int SellIn { get; set; }
    }
}
using Ardalis.GuardClauses;

namespace GildedRose.Stock.Domain
{
    public interface IQuality
    {
        int Value { get; }

        void Decrease();
    }

    //JP: potential for base class, if rule of three applies...
    public class NormalQuality : IQuality
    {
        public NormalQuality(int initialValue)
        {
            Guard.Against.Negative(initialValue, nameof(initialValue));
            Value = initialValue;
        }

        public int Value { get; private set; }

        public void Decrease()
        {
            Value -= 1;
        }
    }
}
using Ardalis.GuardClauses;

namespace GildedRose.Stock.Domain.ValueObjects
{
    public class QualityValue
    {
        private const int maxValue = 50;
        private const int minValue = 0;
        private int currentValue;

        public QualityValue(int initialValue)
        {
            Guard.Against.OutOfRange(initialValue, nameof(initialValue), minValue, maxValue);
            currentValue = initialValue;
        }

        public int Value => currentValue;

        public void DecreaseBy(int decreaseBy)
        {
            Guard.Against.OutOfRange(decreaseBy, nameof(decreaseBy), minValue, maxValue);

            var result = currentValue - decreaseBy;

            if (IsResultBelowTheMinAllowedValue(result))
                SetCurrentValueToMin();
            else
                currentValue = result;
        }

        public void IncreaseBy(int increaseValue)
        {
            Guard.Against.OutOfRange(increaseValue, nameof(increaseValue), minValue, int.MaxValue);

            long result = (long)currentValue + (long)increaseValue;

            if (IsResultOverTheMaxAllowedValue(result))
                SetCurrentValueToMax();
            else
                currentValue = (int)result;
        }

        private bool IsResultBelowTheMinAllowedValue(long result)
        {
            return result < minValue;
        }

        private bool IsResultOverTheMaxAllowedValue(long result)
        {
            return result > maxValue || result > int.MaxValue;
        }

        private void SetCurrentValueToMax()
        {
            currentValue = maxValue;
        }

        private void SetCurrentValueToMin()
        {
            currentValue = minValue;
        }
    }
}
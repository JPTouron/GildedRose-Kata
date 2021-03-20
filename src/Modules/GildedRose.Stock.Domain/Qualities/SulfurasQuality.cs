using Ardalis.GuardClauses;
using GildedRose.Stock.Domain.Qualities.Contracts;
using GildedRose.Stock.Domain.ValueObjects;

namespace GildedRose.Stock.Domain.Qualities
{
    public class SulfurasQuality : IQuality
    {
        private readonly QualityValue currentQuality;

        public SulfurasQuality(QualityValue initialQuality)
        {
            Guard.Against.Null(initialQuality, nameof(initialQuality));
            currentQuality = initialQuality;
        }

        public int Value => currentQuality.Value;
    }
}
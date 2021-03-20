using GildedRose.Stock.Domain.Qualities.Base;
using GildedRose.Stock.Domain.ValueObjects;
using GildedRose.Stock.Domain.ValueObjects.SellIn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Stock.Domain.Qualities
{
    public class BackstagePassQuality : BaseUpdatableQuality
    {
        private IReadOnlyList<QualityUpdateRule> qualityUpdateRules;

        public BackstagePassQuality(QualityValue initialQuality, SellInValueUpdatable initialSellIn) : base(initialQuality, initialSellIn)
        {
            LoadQualityUpdateRules();
        }

        private bool concertHasAlreadyBeenPerformed => currentSellIn.Value <= 0;

        private bool fiveDaysOrLessThanToConcert => currentSellIn.Value <= 5;

        private bool moreThanTenDaysToConcert => currentSellIn.Value > 10;

        private bool tenDaysOrlessToConcert => currentSellIn.Value <= 10;

        protected override void UpdateQualityInternal()
        {
            var noRuleApplied = true;
            var ruleIndex = 0;

            do
            {
                var rule = qualityUpdateRules[ruleIndex];
                noRuleApplied = !rule.Execute();

                ruleIndex++;
            } while (noRuleApplied);
        }

        private void DropQualityToZero()
        {
            currentQuality.DecreaseBy(currentQuality.Value);
        }

        private void IncreaseQualityNormally()
        {
            currentQuality.IncreaseBy(1);
        }

        private void IncreaseQualityThreeTimesAsNormal()
        {
            currentQuality.IncreaseBy(3);
        }

        private void IncreaseQualityTwiceAsNormal()
        {
            currentQuality.IncreaseBy(2);
        }

        private void LoadQualityUpdateRules()
        {
            var rules = new List<QualityUpdateRule>()
            {
                new QualityUpdateRule(0, concertHasAlreadyBeenPerformed, DropQualityToZero),
                new QualityUpdateRule(1, fiveDaysOrLessThanToConcert, IncreaseQualityThreeTimesAsNormal),
                new QualityUpdateRule(2, tenDaysOrlessToConcert, IncreaseQualityTwiceAsNormal),
                new QualityUpdateRule(3, moreThanTenDaysToConcert, IncreaseQualityNormally),
            };

            qualityUpdateRules = rules.OrderBy(x => x.RuleOrder).ToList();
        }

        private class QualityUpdateRule
        {
            private readonly Action qualityUpdater;
            private readonly bool sellInValidator;

            public QualityUpdateRule(int ruleOrder, bool sellInValidator, Action qualityUpdater)
            {
                RuleOrder = ruleOrder;
                this.sellInValidator = sellInValidator;
                this.qualityUpdater = qualityUpdater;
            }

            public int RuleOrder { get; }

            public bool Execute()
            {
                var ruleApplies = sellInValidator;
                if (ruleApplies)
                    qualityUpdater();

                return ruleApplies;
            }
        }
    }
}
using GildedRose.Core.BuildingBlocks;
using GildedRose.Stock.Domain.Qualities.Base.Contracts;

namespace GildedRose.Stock.Domain.ValueObjects
{
    /*
     * JP: this class could be implemented as inheritance:
     * - having a base class to define the Value {get} prop
     * - having an inheriting class adding DecreaseValue() method
     * and make both public, however that would lead to having the base class not abstract which is fine in of itself
     * BUT its crap when you have to make the currentValue private member protected so children may mess with it
     * as the base class would not be abstract then it's weird to have such a protected member
     *
     * I'd rather go by having an internal class and the public abstractions definitions I really need: the Ifaces this class implements
     */

    internal class SellInValue : ValueObject<SellInValue>, ISellInValue, IDecreasableSellInValue
    {
        private const int decreaseBy = 1;
        private int currentValue;

        public SellInValue(int initialValue)
        {
            currentValue = initialValue;
        }

        public int Value => currentValue;

        public void DecreaseValue()
        {
            currentValue -= decreaseBy;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        protected override bool InternalEquals(SellInValue other)
        {
            return Value.Equals(other.Value);
        }
    }
}
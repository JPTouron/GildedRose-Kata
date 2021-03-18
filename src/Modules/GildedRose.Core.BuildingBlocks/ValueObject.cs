using System;

namespace GildedRose.Core.BuildingBlocks
{
    public abstract class ValueObject<T> : IEquatable<T>
      where T : ValueObject<T>
    {
        public static bool operator !=(ValueObject<T> right, ValueObject<T> left)
        {
            return !(right == left);
        }

        public static bool operator ==(ValueObject<T> right, ValueObject<T> left)
        {
            if (Equals(right, null))
            {
                if (Equals(left, null))
                {
                    return true;
                }
                return false;
            }
            return right.Equals(left);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(T)) return false;

            return InternalEquals((T)obj);
        }

        public bool Equals(T other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return InternalEquals(other);
        }

        public abstract override int GetHashCode();

        protected abstract bool InternalEquals(T other);
    }
}
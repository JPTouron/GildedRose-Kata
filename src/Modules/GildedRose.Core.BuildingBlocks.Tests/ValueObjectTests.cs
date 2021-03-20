using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;

namespace GildedRose.Core.BuildingBlocks.Tests
{
    public class ValueObjectTests
    {
        private Address a1;
        private Address a2;
        private IFixture fixture;

        public ValueObjectTests()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }

        [Fact]
        public void EqualOperator_NullChecks()
        {
            a1 = null;
            a2 = null;

            Assert.True(a1 == null);
            Assert.True(null == a1);

            Assert.True(a1 == a2);
            Assert.True(a2 == a1);
        }

        [Fact]
        public void Equals_NullChecks()
        {
            CreateDifferentAddresses();
            a2 = null;

            Assert.False(a1.Equals(a2));
            Assert.False(a1.Equals(a2 as object));
        }

        [Fact]
        public void Equals_TypeChecks()
        {
            CreateDifferentAddresses();
            var differentObject = 10;

            Assert.False(a1.Equals(differentObject));
        }

        [Fact]
        public void Equals_TypeChecks_ReturnsFalseWhenComparedToADifferentType()
        {
            CreateDifferentAddresses();
            var differentObject = 10;

            Assert.False(a1.Equals(differentObject));
        }

        [Fact]
        public void Equals_TypeChecks_ReturnsTrueWhenComparedToSameReference()
        {
            CreateDifferentAddresses();

            Assert.True(a1.Equals(a1));
        }

        [Fact]
        public void Equals_TypeChecksAsObjects_ReturnsTrueWhenComparedToSameReference()
        {
            CreateDifferentAddresses();

            var o = a1 as object;
            Assert.True(a1.Equals(o));
        }

        [Fact]
        public void NotEqualsOperator_NullChecks()
        {
            CreateDifferentAddresses();
            a2 = null;

            Assert.False(a2 != null);
            Assert.False(null != a2);

            Assert.True(a1 != a2);
            Assert.True(a2 != a1);
        }

        [Fact]
        public void WhenAddressesDifferent_ThenDifferentOperatorISTrue()
        {
            CreateDifferentAddresses();

            Assert.NotEqual(a1.StreetName, a2.StreetName);
            Assert.NotEqual(a1.StreetNumber, a2.StreetNumber);
            Assert.NotEqual(a1.ZipCode, a2.ZipCode);

            Assert.True(a1 != a2);
            Assert.True(a2 != a1);
        }

        [Fact]
        public void WhenAddressesDifferent_ThenEqualOperatorISFalse()
        {
            CreateDifferentAddresses();

            Assert.NotEqual(a1.StreetName, a2.StreetName);
            Assert.NotEqual(a1.StreetNumber, a2.StreetNumber);
            Assert.NotEqual(a1.ZipCode, a2.ZipCode);

            Assert.False(a1 == a2);
            Assert.False(a2 == a1);
        }

        [Fact]
        public void WhenAddressesDifferent_ThenEqualsIsFalse()
        {
            CreateDifferentAddresses();

            Assert.NotEqual(a1.StreetName, a2.StreetName);
            Assert.NotEqual(a1.StreetNumber, a2.StreetNumber);
            Assert.NotEqual(a1.ZipCode, a2.ZipCode);

            Assert.False(a1.Equals(a2));
            Assert.False(a2.Equals(a1));
        }

        [Fact]
        public void WhenAddressesDifferent_ThenHashCodeDifferent()
        {
            CreateDifferentAddresses();

            Assert.NotEqual(a1.StreetName, a2.StreetName);
            Assert.NotEqual(a1.StreetNumber, a2.StreetNumber);
            Assert.NotEqual(a1.ZipCode, a2.ZipCode);
            Assert.NotEqual(a1.GetHashCode(), a2.GetHashCode());
        }

        [Fact]
        public void WhenAddressesEqual_ThenEqualsIsTrue()
        {
            CreateDuplicateAddresses();

            Assert.Equal(a1.StreetName, a2.StreetName);
            Assert.Equal(a1.StreetNumber, a2.StreetNumber);
            Assert.Equal(a1.ZipCode, a2.ZipCode);

            Assert.True(a1.Equals(a2));
            Assert.True(a2.Equals(a1));
        }

        [Fact]
        public void WhenAddressesEqual_ThenHashCodeEqual()
        {
            CreateDuplicateAddresses();

            Assert.Equal(a1.StreetName, a2.StreetName);
            Assert.Equal(a1.StreetNumber, a2.StreetNumber);
            Assert.Equal(a1.ZipCode, a2.ZipCode);
            Assert.Equal(a1.GetHashCode(), a2.GetHashCode());
        }

        [Fact]
        public void WhenAddressesSame_ThenDifferentOperatorISFalse()
        {
            CreateDuplicateAddresses();

            Assert.Equal(a1.StreetName, a2.StreetName);
            Assert.Equal(a1.StreetNumber, a2.StreetNumber);
            Assert.Equal(a1.ZipCode, a2.ZipCode);

            Assert.False(a1 != a2);
            Assert.False(a2 != a1);
        }

        [Fact]
        public void WhenAddressesSame_ThenEqualOperatorISTrue()
        {
            CreateDuplicateAddresses();

            Assert.Equal(a1.StreetName, a2.StreetName);
            Assert.Equal(a1.StreetNumber, a2.StreetNumber);
            Assert.Equal(a1.ZipCode, a2.ZipCode);

            Assert.True(a1 == a2);
            Assert.True(a2 == a1);
        }

        private void CreateDifferentAddresses()
        {
            a1 = fixture.Create<Address>();
            a2 = fixture.Create<Address>();
        }

        private void CreateDuplicateAddresses()
        {
            a1 = fixture.Create<Address>();
            a2 = fixture.Build<Address>()
                .With(x => x.StreetName, a1.StreetName)
                .With(x => x.StreetNumber, a1.StreetNumber)
                .With(x => x.ZipCode, a1.ZipCode)
                .Create();
        }

        public class Address : ValueObject<Address>
        {
            public string StreetName;
            public int StreetNumber;
            public string ZipCode;

            public Address()
            {
                StreetName = ZipCode = string.Empty;
                StreetNumber = 0;
            }

            public override int GetHashCode()
            {
                return StreetName.GetHashCode() ^ StreetNumber.GetHashCode() ^ ZipCode.GetHashCode();
            }

            protected override bool InternalEquals(Address other)
            {
                var c1 = StreetName.Equals(other.StreetName);
                var c2 = StreetNumber.Equals(other.StreetNumber);
                var c3 = ZipCode.Equals(other.ZipCode);

                return c1 && c2 && c3;
            }
        }
    }
}

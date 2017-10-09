using System;
using Xunit;
using GlobalBlue.Models;
using GlobalBlue.Services;

namespace GlobalBlue.Tests
{
    public class AddressValidatorTests
    {
        private readonly IAddressValidator _addressValidator;

        public AddressValidatorTests()
        {
            _addressValidator = new AddressValidator();
        }

        [Fact]
        public void Address_NullAddress_ReturnFalse()
        {
            var isValid = _addressValidator.IsValid(null);

            Assert.False(isValid);
        }

        [Fact]
        public void Address_EmptyStreetAddress_ReturnFalse()
        {
            // Same with OfficeAddress class
            var address = new HomeAddress
            {
                Zip = "123456",
                City = "Test City",
                Country = "Test Country"
            };

            var isValid = _addressValidator.IsValid(address);

            Assert.False(isValid);
        }

        [Fact]
        public void Address_EmptyZip_ReturnFalse()
        {
            // Same with OfficeAddress class
            var address = new HomeAddress
            {
                StreetAddress1 = "Test Street",
                City = "Test City",
                Country = "Test Country"
            };

            var isValid = _addressValidator.IsValid(address);

            Assert.False(isValid);
        }

        [Fact]
        public void Address_EmptyCity_ReturnFalse()
        {
            // Same with OfficeAddress class
            var address = new HomeAddress
            {
                StreetAddress1 = "Test Street",
                Zip = "123456",
                Country = "Test Country"
            };

            var isValid = _addressValidator.IsValid(address);

            Assert.False(isValid);
        }

        [Fact]
        public void Address_EmptyCountry_ReturnFalse()
        {
            // Same with OfficeAddress class
            var address = new HomeAddress
            {
                StreetAddress1 = "Test Street",
                Zip = "123456",
                City = "Test City"
            };

            var isValid = _addressValidator.IsValid(address);

            Assert.False(isValid);
        }

        [Fact]
        public void Address_Valid_ReturnTrue()
        {
            // Same with OfficeAddress class
            var address = new HomeAddress
            {
                StreetAddress1 = "Test Street",
                Zip = "123456",
                City = "Test City",
                Country = "Test Country"
            };

            var isValid = _addressValidator.IsValid(address);

            Assert.True(isValid);
        }
    }
}

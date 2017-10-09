using GlobalBlue.Models;
using GlobalBlue.Services;
using Moq;
using Xunit;

namespace GlobalBlue.Tests
{
    public class ShippingDetailsValidatorTests
    {
        private readonly IShippingDetailsValidator _shippingValidator;
        private readonly IAddressValidator _addressValidator;

        public ShippingDetailsValidatorTests()
        {
            var addressValidator = new Mock<IAddressValidator>();
            addressValidator.Setup(a => a.IsValid(It.IsAny<Address>()))
                .Returns(true);
            _shippingValidator = new ShippingDetailsValidator(addressValidator.Object);
            _addressValidator = new AddressValidator();
        }

        [Fact]
        public void Shipping_NullShipping_ReturnFalse()
        {
            var isValid = _shippingValidator.IsValid(null);

            Assert.False(isValid);
        }

        [Fact]
        public void Shipping_ValidDetails_ReturnTrue()
        {
            var shipping = new ShippingDetails();
            
            var isValid = _shippingValidator.IsValid(shipping);

            Assert.True(isValid);
        }

        [Fact]
        public void Shipping_NullHome_NullOffice_ReturnTrue()
        {
            // For us to test this, we must use 
            // the actual address validator
            var shippingValidator = new ShippingDetailsValidator(_addressValidator);

            var shipping = new ShippingDetails
            {
                HomeAddress = null,
                OfficeAddress = null
            };
            
            var isValid = shippingValidator.IsValid(shipping);

            Assert.False(isValid);
        }

        [Fact]
        public void Shipping_ValidHome_NullOffice_ReturnTrue()
        {
            // For us to test this, we must use 
            // the actual address validator
            var shippingValidator = new ShippingDetailsValidator(_addressValidator);

            var shipping = new ShippingDetails
            {
                HomeAddress = new HomeAddress 
                {
                    StreetAddress1 = "Test Street",
                    Zip = "123456",
                    City = "Test City",
                    Country = "Test Country"
                },
                OfficeAddress = null
            };
            
            var isValid = shippingValidator.IsValid(shipping);

            Assert.True(isValid);
        }

        [Fact]
        public void Shipping_NullHome_ValidOffice_ReturnTrue()
        {
            // For us to test this, we must use 
            // the actual address validator
            var shippingValidator = new ShippingDetailsValidator(_addressValidator);

            var shipping = new ShippingDetails
            {
                HomeAddress = null,
                OfficeAddress = new OfficeAddress 
                {
                    StreetAddress1 = "Test Street",
                    Zip = "123456",
                    City = "Test City",
                    Country = "Test Country"
                }
            };
            
            var isValid = shippingValidator.IsValid(shipping);

            Assert.True(isValid);
        }
    }
}
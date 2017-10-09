using GlobalBlue.Models;
using GlobalBlue.Services;
using Moq;
using Xunit;

namespace GlobalBlue.Tests
{
    public class ShoppingCartValidatorTests 
    {
        private IShoppingCartValidator _shoppingValidator;
        private Mock<ICartDetailsValidator> _cartValidator;
        private Mock<IShippingDetailsValidator> _shippingValidator;

        public ShoppingCartValidatorTests()
        {
            _cartValidator = new Mock<ICartDetailsValidator>();
            _shippingValidator = new Mock<IShippingDetailsValidator>();
        }

        [Fact]
        public void Shopping_Null_ReturnFalse()
        {
            // Setup mock
            _shoppingValidator = new ShoppingCartValidator(_cartValidator.Object
            , _shippingValidator.Object);

            var isValid = _shoppingValidator.IsValid(null);

            Assert.False(isValid);
        }

        [Fact]
        public void Shopping_ValidCart_NullShipping_ReturnFalse()
        {
            // Setup mock
            _cartValidator.Setup(c => c.IsValid(It.IsAny<CartDetails>())).Returns(true);
            _shippingValidator.Setup(c => c.IsValid(null)).Returns(false);
            _shoppingValidator = new ShoppingCartValidator(_cartValidator.Object
            , _shippingValidator.Object);

            var shoppingCart = new ShoppingCart();
            var isValid = _shoppingValidator.IsValid(shoppingCart);

            Assert.False(isValid);
        }

        [Fact]
        public void Shopping_NullCart_ValidShipping_ReturnFalse()
        {
            // Setup mock
            _cartValidator.Setup(c => c.IsValid(null)).Returns(false);
            _shippingValidator.Setup(c => c.IsValid(It.IsAny<ShippingDetails>())).Returns(true);
            _shoppingValidator = new ShoppingCartValidator(_cartValidator.Object
            , _shippingValidator.Object);

            var shoppingCart = new ShoppingCart();
            var isValid = _shoppingValidator.IsValid(shoppingCart);

            Assert.False(isValid);
        }

        [Fact]
        public void Shopping_Valid_ReturnTrue()
        {
            // Setup mock
            _cartValidator.Setup(c => c.IsValid(It.IsAny<CartDetails>())).Returns(true);
            _shippingValidator.Setup(c => c.IsValid(It.IsAny<ShippingDetails>())).Returns(true);
            _shoppingValidator = new ShoppingCartValidator(_cartValidator.Object
            , _shippingValidator.Object);

            var shoppingCart = new ShoppingCart();
            var isValid = _shoppingValidator.IsValid(shoppingCart);

            Assert.True(isValid);
        }
    }
}
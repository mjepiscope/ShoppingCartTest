using System.Collections.Generic;
using GlobalBlue.Models;
using GlobalBlue.Services;
using Xunit;

namespace GlobalBlue.Tests
{
    public class CartDetailsValidatorTests
    {
        private readonly ICartDetailsValidator _cartValidator;

        public CartDetailsValidatorTests()
        {
            _cartValidator = new CartDetailsValidator();
        }

        [Fact]
        public void Cart_NullCart_ReturnFalse()
        {
            var isValid = _cartValidator.IsValid(null);

            Assert.False(isValid);
        }

        [Fact]
        public void Cart_NullItems_ReturnFalse()
        {
            var cart = new CartDetails
            {
                Items = null
            };

            var isValid = _cartValidator.IsValid(cart);

            Assert.False(isValid);
        }

        [Fact]
        public void Cart_EmptyItems_ReturnFalse()
        {
            var cart = new CartDetails
            {
                Items = new List<Item>()
            };
            
            var isValid = _cartValidator.IsValid(cart);

            Assert.False(isValid);
        }

        [Fact]
        public void Cart_NullItemId_ReturnFalse()
        {
            var cart = new CartDetails
            {
                Items = new List<Item>
                {
                    new Item 
                    {
                        ItemId = null,
                        Qty = 10
                    }
                }
            };
            
            var isValid = _cartValidator.IsValid(cart);

            Assert.False(isValid);
        }

        [Fact]
        public void Cart_EmptyItemId_ReturnFalse()
        {
            var cart = new CartDetails
            {
                Items = new List<Item>
                {
                    new Item 
                    {
                        ItemId = string.Empty,
                        Qty = 10
                    }
                }
            };
            
            var isValid = _cartValidator.IsValid(cart);

            Assert.False(isValid);
        }

        [Fact]
        public void Cart_InvalidQty_ReturnFalse()
        {
            var cart = new CartDetails
            {
                Items = new List<Item>
                {
                    new Item 
                    {
                        ItemId = "Test",
                        Qty = 0
                    }
                }
            };
            
            var isValid = _cartValidator.IsValid(cart);

            Assert.False(isValid);
        }

        [Fact]
        public void Cart_ValidItems_ReturnTrue()
        {
            var cart = new CartDetails
            {
                Items = new List<Item>
                {
                    new Item 
                    {
                        ItemId = "Test1",
                        Qty = 10
                    },
                    new Item 
                    {
                        ItemId = "Test2",
                        Qty = 100
                    }
                }
            };
            
            var isValid = _cartValidator.IsValid(cart);

            Assert.True(isValid);
        }
    }
}
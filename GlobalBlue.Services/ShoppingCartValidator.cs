using System;
using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public class ShoppingCartValidator : IShoppingCartValidator
    {
        private ICartDetailsValidator _cartValidator;
        private IShippingDetailsValidator _shippingValidator;

        public ShoppingCartValidator(ICartDetailsValidator cartValidator, IShippingDetailsValidator shippingValidator)
        {
            _cartValidator = cartValidator;
            _shippingValidator = shippingValidator;
        }
        public bool IsValid(ShoppingCart shoppingCart)
        {
            var isValid = false;

            if (shoppingCart != null)
            {
                isValid = _cartValidator.IsValid(shoppingCart.CartDetails)
                    && _shippingValidator.IsValid(shoppingCart.ShippingDetails);
            }

            return isValid;
        }
    }
}

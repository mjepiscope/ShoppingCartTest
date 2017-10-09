using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public class ShippingDetailsValidator : IShippingDetailsValidator
    {
        private IAddressValidator _addressValidator;

        public ShippingDetailsValidator(IAddressValidator addressValidator)
        {
            _addressValidator = addressValidator;
        }

        public bool IsValid(ShippingDetails shipping)
        {
            var isValid = false;

            if (shipping != null)
            {
                isValid = _addressValidator.IsValid(shipping.HomeAddress)
                    || _addressValidator.IsValid(shipping.OfficeAddress);
            }

            return isValid;
        }
    }
}
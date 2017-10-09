using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public class AddressValidator : IAddressValidator
    {
        public bool IsValid(Address address)
        {
            var isValid = false;

            isValid = address != null
                && !string.IsNullOrEmpty(address.StreetAddress1)
                && !string.IsNullOrEmpty(address.Zip)
                && !string.IsNullOrEmpty(address.City)
                && !string.IsNullOrEmpty(address.Country);

            return isValid;
        }
    }
}
using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public interface IShippingDetailsValidator
    {
        bool IsValid(ShippingDetails shipping);
    }
}
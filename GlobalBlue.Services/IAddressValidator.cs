using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public interface IAddressValidator
    {
        bool IsValid(Address address);
    }
}
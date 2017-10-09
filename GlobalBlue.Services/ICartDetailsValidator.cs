using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public interface ICartDetailsValidator
    {
        bool IsValid(CartDetails cart);
    }
}
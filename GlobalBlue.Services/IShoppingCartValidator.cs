using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public interface IShoppingCartValidator
    {
        bool IsValid(ShoppingCart shoppingCart);
    }
}
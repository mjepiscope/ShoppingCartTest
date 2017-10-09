using System.Linq;
using GlobalBlue.Models;

namespace GlobalBlue.Services
{
    public class CartDetailsValidator : ICartDetailsValidator
    {
        public bool IsValid(CartDetails cart)
        {
            var isValid = false;

            if (cart != null && cart.Items != null && cart.Items.Count > 0)
            {
                isValid = cart.Items.All(i => !string.IsNullOrEmpty(i.ItemId)
                    && i.Qty.HasValue
                    && i.Qty > 0);
            }

            return isValid;
        }
    }
}
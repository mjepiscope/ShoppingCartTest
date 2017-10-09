using System.Collections.Generic;

namespace GlobalBlue.Models
{
    public class CartDetails
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public List<Item> Items { get; set; }
    }
}
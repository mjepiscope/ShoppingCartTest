using System;

namespace GlobalBlue.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public CartDetails CartDetails { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
}

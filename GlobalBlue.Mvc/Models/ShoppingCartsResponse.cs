using System;
using System.Collections.Generic;
using GlobalBlue.Models;

namespace GlobalBlue.Mvc.Models
{
    [Serializable]
    public class ShoppingCartsResponse
    {
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public string ErrorMessage { get; set; }
    }
}
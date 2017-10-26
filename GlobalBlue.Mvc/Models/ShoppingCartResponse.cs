using System;
using System.Collections.Generic;
using GlobalBlue.Models;

namespace GlobalBlue.Mvc.Models
{
    [Serializable]
    public class ShoppingCartResponse
    {
        public ShoppingCart ShoppingCart { get; set; }
        public string ErrorMessage { get; set; }
    }
}
using System;
using System.Collections.Generic;
using GlobalBlue.Models;

namespace GlobalBlue.Mvc.Models
{
    [Serializable]
    public class ShoppingCartUpdateRequest
    {
        public ShoppingCart ShoppingCart { get; set; }
        public List<Item> DeletedItems { get; set; }
    }
}
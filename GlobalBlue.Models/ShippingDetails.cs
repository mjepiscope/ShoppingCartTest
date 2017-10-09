namespace GlobalBlue.Models
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public HomeAddress HomeAddress { get; set; }
        public OfficeAddress OfficeAddress { get; set; }
    }
}
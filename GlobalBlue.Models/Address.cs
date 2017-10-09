namespace GlobalBlue.Models
{
    public abstract class Address
    {
        public int Id { get; set; }
        public int ShippingDetailsId { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string StreetAddress3 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
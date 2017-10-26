namespace GlobalBlue.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public int? CartDetailsId { get; set; }
        public int? Qty { get; set; }
    }
}
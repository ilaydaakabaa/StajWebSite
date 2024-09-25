namespace WebAppBaslangc.Models
{
    public class ShoppingCardViewModel
    {
        public List<ShoppingCardItem>cardItems { get; set; }
        public decimal? totalPrice { get; set; }    
        public int? totalQuantity { get; set; }
    }
}

using WebAppBaslangc.Migrations;

namespace WebAppBaslangc.Models
{
    public class ShoppingCardItem
    {
        public int ıd { get; set; }
        public Biycle biycle { get; set; }
        public int  quantity{ get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public decimal price { get; set; }

    }
}

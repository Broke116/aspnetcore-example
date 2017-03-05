using System;

namespace aspnetcoreapp1.Models
{
    public class ProductDetailsViewModel : ProductViewModel
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}

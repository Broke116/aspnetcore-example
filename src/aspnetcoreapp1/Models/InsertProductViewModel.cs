using System;
using aspnetcoreapp1.Domains;

namespace aspnetcoreapp1.Models
{
    public class InsertProductViewModel
    {
        public string Title { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

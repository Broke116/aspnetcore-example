using System;

namespace coreapp_database.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}

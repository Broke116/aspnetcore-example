using System.Collections.Generic;

namespace coreapp_database.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

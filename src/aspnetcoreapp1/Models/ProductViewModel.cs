using aspnetcoreapp1.Domains;

namespace aspnetcoreapp1.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
    }
}

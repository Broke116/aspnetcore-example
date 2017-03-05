using System.Collections.Generic;

namespace aspnetcoreapp1.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> ProductViewModels { get; set; }
        public int TotalProductsAvailable { get; set; }
    }
}

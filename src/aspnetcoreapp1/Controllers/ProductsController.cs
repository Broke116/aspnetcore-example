using System.Collections.Generic;
using aspnetcoreapp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View(GetBooks());
        }

        private IEnumerable<ProductViewModel> GetBooks()
        {
            return new List<ProductViewModel>()
            {
                new ProductViewModel() {Id = 1, Category = "Technology", Title = "Toshiba laptop" },
                new ProductViewModel() {Id = 2, Category = "Sports", Title = "Bike" },
                new ProductViewModel() {Id = 3, Category = "Technology", Title = "Samsung Galaxy S5" },
                new ProductViewModel() {Id = 4, Category = "Technology", Title = "IPhone 6s" },
                new ProductViewModel() {Id = 5, Category = "Sports", Title = "Baseball bat" }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcoreapp1.Models;
using aspnetcoreapp1.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            if (productService == null) throw new ArgumentNullException("Product service!");
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(GetAll());
        }

        private IEnumerable<ProductViewModel> GetAll()
        {
            var products = _productService.GetAll();
            return (from p in products select new ProductViewModel() { Id = p.Id, Category = p.Category, Title = p.Title});
        }
    }
}

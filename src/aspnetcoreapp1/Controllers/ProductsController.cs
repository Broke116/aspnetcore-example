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
            var productViewModels = GetAll();
            var productIndexViewModel = new ProductIndexViewModel
            {
                ProductViewModels = productViewModels,
                TotalProductsAvailable = productViewModels.Count()
            };
            return View(productIndexViewModel);
        }

        public IActionResult Detail(int id)
        {
            var productDetailsViewModel = new ProductDetailsViewModel();
            var product = _productService.GetBy(id);
            if (product != null)
            {
                productDetailsViewModel.Id = product.Id;
                productDetailsViewModel.Quantity = product.Quantity;
                productDetailsViewModel.Category = product.Category;
                productDetailsViewModel.Price = product.Price;
                productDetailsViewModel.Title = product.Title;
                productDetailsViewModel.Date = product.Date;
            }
            else
            {
                RedirectToAction("Index");
            }

            return View(productDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var insertProductViewModel = new InsertProductViewModel();
            return View(insertProductViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsertProductViewModel insertProductViewModel)
        {
            var newProduct = new Product()
            {
                Title = insertProductViewModel.Title,
                Category = insertProductViewModel.Category,
                Date = DateTime.UtcNow,
                Price = insertProductViewModel.Price,
                Quantity = insertProductViewModel.Quantity
            };
            _productService.Add(newProduct);
            return RedirectToAction("Index");
        }

        private IEnumerable<ProductViewModel> GetAll()
        {
            var products = _productService.GetAll();
            return (from p in products select new ProductViewModel() { Id = p.Id, Category = p.Category, Title = p.Title});
        }
    }
}

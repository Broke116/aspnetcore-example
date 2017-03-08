using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcoreapp1.Domains;
using aspnetcoreapp1.Models;

namespace aspnetcoreapp1.Repositories
{// dummy repo without DB
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, Category = Category.Technology, Title = "Toshiba laptop", Quantity = 4, Price = 1500, Date = DateTime.UtcNow},
                new Product() { Id = 2, Category = Category.Sports, Title = "Bike", Quantity = 14, Price = 120 },
                new Product() { Id = 3, Category = Category.Technology, Title = "Samsung Galaxy S5", Quantity = 2, Price = 1800, Date = DateTime.UtcNow },
                new Product() { Id = 4, Category = Category.Technology, Title = "IPhone 6s", Quantity = 10, Price = 3500, Date = DateTime.UtcNow },
                new Product() { Id = 5, Category = Category.Sports, Title = "Baseball bat", Quantity = 2, Price = 50, Date = DateTime.UtcNow }
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetBy(int id)
        {
            return (from p in _products where p.Id == id select p).FirstOrDefault();
        }

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }
    }
}

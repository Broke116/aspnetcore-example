using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreapp_database.Models;

namespace coreapp_database
{
    public class DbInitializer
    {
        public static void Initialize(ShopContext shopContext)
        {
            shopContext.Database.EnsureCreated();

            if (shopContext.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product() { ID = 1, CategoryID = 1, Title = "Toshiba laptop", Quantity = 4, Price = 1500, Date = DateTime.UtcNow},
                new Product() { ID = 2, CategoryID = 2, Title = "Bike", Quantity = 14, Price = 120 },
                new Product() { ID = 3, CategoryID = 1, Title = "Samsung Galaxy S5", Quantity = 2, Price = 1800, Date = DateTime.UtcNow },
                new Product() { ID = 4, CategoryID = 1, Title = "IPhone 6s", Quantity = 10, Price = 3500, Date = DateTime.UtcNow },
                new Product() { ID = 5, CategoryID = 2, Title = "Baseball bat", Quantity = 2, Price = 50, Date = DateTime.UtcNow }
            };

            foreach (var p in products)
            {
                shopContext.Products.Add(p);
            }

            shopContext.SaveChanges();

            var categories = new Category[]
            {
                new Category() { ID = 1, Title = "Technology" },
                new Category() { ID = 2, Title = "Sports" }
            };

            foreach (var c in categories)
            {
                shopContext.Categories.Add(c);
            }

            shopContext.SaveChanges();
        }
    }
}

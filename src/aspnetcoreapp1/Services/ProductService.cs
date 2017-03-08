using System;
using System.Collections.Generic;
using aspnetcoreapp1.Models;
using aspnetcoreapp1.Repositories;

namespace aspnetcoreapp1.Services
{
    public class ProductService : IProductService // will delegate the database handling job to the repository
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null) throw new ArgumentNullException("Product repository");
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _productRepository.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Product GetBy(int id)
        {
            try
            {
                return _productRepository.GetBy(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Add(Product product)
        {
            try
            {
                _productRepository.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

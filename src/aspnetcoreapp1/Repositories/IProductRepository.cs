using System.Collections.Generic;
using aspnetcoreapp1.Models;

namespace aspnetcoreapp1.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetBy(int id);
    }
}

﻿using System.Collections.Generic;
using aspnetcoreapp1.Models;

namespace aspnetcoreapp1.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
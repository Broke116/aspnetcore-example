using System.Collections.Generic;
using aspnetcoreapp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

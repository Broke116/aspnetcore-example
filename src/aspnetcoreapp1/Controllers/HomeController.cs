using aspnetcoreapp1.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringFormatter _stringFormatter;

        public HomeController(IStringFormatter stringFormatter)
        {
            _stringFormatter = stringFormatter;
        }

        public IActionResult Index()
        {
            ViewData["depMessage"] = _stringFormatter.FormatIt(new { Message = "Hello DI" });

            return View();
        }
    }
}

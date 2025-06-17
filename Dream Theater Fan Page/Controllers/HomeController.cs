using Dream_Theater_Fan_Page.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class HomeController : Controller
    {
        private readonly DreamTheaterFanPageContext _DbContext;

        public HomeController(DreamTheaterFanPageContext _context)
        {
            _DbContext = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}

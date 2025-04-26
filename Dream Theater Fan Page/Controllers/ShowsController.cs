using Microsoft.AspNetCore.Mvc;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class ShowsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

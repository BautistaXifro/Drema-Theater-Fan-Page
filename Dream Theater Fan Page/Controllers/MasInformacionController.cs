using Microsoft.AspNetCore.Mvc;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class MasInformacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarMensaje(string name, string email, string message)
        {

            ViewBag.Message = "¡Mensaje enviado correctamente!";
            return View("Index");
        }
    }
}

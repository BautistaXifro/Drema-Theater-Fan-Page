using Dream_Theater_Fan_Page.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class BandaController : Controller
    {
        private readonly DreamTheaterFanPageContext _context;

        public BandaController(DreamTheaterFanPageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bandas = _context.Banda.ToList();
            return View(bandas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Banda banda)
        {
            if (ModelState.IsValid)
            {
                _context.Banda.Add(banda);
                _context.SaveChanges();

                return RedirectToAction("Index", "Integrante", new { bandaId = banda.BandaId });
            }
            return View(banda);
        }

        public IActionResult Edit(int id)
        {
            var banda = _context.Banda.Find(id);
            if (banda == null) return NotFound();
            return View(banda);
        }

        [HttpPost]
        public IActionResult Edit(Banda banda)
        {
            if (ModelState.IsValid)
            {
                _context.Banda.Update(banda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banda);
        }

        public IActionResult Delete(int id)
        {

            var banda = _context.Banda.Find(id);
            if (banda == null) return NotFound();
            
            var integrantes = _context.Integrantes.Where(i => i.BandaId == id).ToList();

            if (integrantes.Any())
            {
                _context.Integrantes.RemoveRange(integrantes);
            }

            _context.Banda.Remove(banda);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

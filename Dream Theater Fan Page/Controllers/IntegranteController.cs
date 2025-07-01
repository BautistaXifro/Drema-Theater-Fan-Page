using Dream_Theater_Fan_Page.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class IntegranteController : Controller
    {
        private readonly DreamTheaterFanPageContext _context;

        public IntegranteController(DreamTheaterFanPageContext context)
        {
            _context = context;
        }

        public IActionResult Index(int bandaId)
        {
            var integrantes = _context.Integrantes.Where(i => i.BandaId == bandaId).ToList();
            ViewBag.BandaId = bandaId;
            ViewBag.BandaNombre = _context.Banda.Where(b => b.BandaId == bandaId).Select(b => b.Nombre).FirstOrDefault();
            return View(integrantes);
        }

        public IActionResult Create(int bandaId)
        {
            var integrante = new Integrante { BandaId = bandaId };
            ViewBag.BandaId = bandaId;
            return View(integrante);
        }

        [HttpPost]
        public IActionResult Create(Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                _context.Integrantes.Add(integrante);
                _context.SaveChanges();
                return RedirectToAction("Index", new { bandaId = integrante.BandaId });
            }
            return View(integrante);
        }

        public IActionResult Edit(int id)
        {
            var integrante = _context.Integrantes.Find(id);
            if (integrante == null) return NotFound();
            return View(integrante);
        }

        [HttpPost]
        public IActionResult Edit(Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                _context.Integrantes.Update(integrante);
                _context.SaveChanges();
                return RedirectToAction("Index", new { bandaId = integrante.BandaId });
            }
            return View(integrante);
        }

        public IActionResult Delete(int id)
        {
            var integrante = _context.Integrantes.Find(id);
            if (integrante == null) return NotFound();

            var bandaId = integrante.BandaId;

            _context.Integrantes.Remove(integrante);
            _context.SaveChanges();

            return RedirectToAction("Index", new { bandaId });
        }
    }
}

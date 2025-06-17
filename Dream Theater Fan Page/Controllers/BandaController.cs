using Dream_Theater_Fan_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create(Banda banda, List<IntegranteDTO> integrantes)
        {
            if (ModelState.IsValid)
            {
                banda.Integrantes = null;
                // Agregamos la Banda primero
                _context.Banda.Add(banda);
                _context.SaveChanges(); // Se genera el BandaId

                // Creamos nuevos objetos Integrante a partir de los DTOs
                foreach (var dto in integrantes)
                {
                    var nuevoIntegrante = new Integrante
                    {
                        Nombre = dto.Nombre,
                        Instrumento = dto.Instrumento,
                        Biografia = dto.Biografia,
                        BandaId = banda.BandaId
                    };
                    _context.Integrantes.Add(nuevoIntegrante);
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banda);
        }

        public IActionResult Edit(int id)
        {
            var banda = _context.Banda.Find(id);
            if (banda == null)
                return NotFound();

            return View(banda);
        }

        [HttpPost]
        public IActionResult Edit(Banda banda)
        {
            if (ModelState.IsValid)
            {
                _context.Update(banda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banda);
        }

        public IActionResult Delete(int id)
        {
            var banda = _context.Banda.Find(id);
            if (banda == null)
                return NotFound();

            _context.Banda.Remove(banda);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Integrantes(int id)
        {
            var integrantes = _context.Integrantes
                .Where(i => i.BandaId == id)
                .ToList();

            ViewBag.BandaNombre = _context.Banda
                .Where(b => b.BandaId == id)
                .Select(b => b.Nombre)
                .FirstOrDefault();

            return View(integrantes);
        }
    }
}

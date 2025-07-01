using Dream_Theater_Fan_Page.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class BandaController : Controller
    {
        private readonly DreamTheaterFanPageContext _context;
        private readonly string ImagenFilePath;
        public BandaController(DreamTheaterFanPageContext context)
        {
            _context = context;
            ImagenFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 5;
            var totalItems = _context.Banda.Count();

            var pager = new Pager(totalItems, page, pageSize);

            var bandas = _context.Banda.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Pager = pager;

            return View(bandas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Banda banda, IFormFile? PhotoFile)
        {
            if (ModelState.IsValid)
            {
                if (PhotoFile != null && PhotoFile.Length > 0)
                {
                    if (!Directory.Exists(ImagenFilePath))
                        Directory.CreateDirectory(ImagenFilePath);

                    var mFileName = Guid.NewGuid() + Path.GetExtension(PhotoFile.FileName);
                    var mPath = Path.Combine(ImagenFilePath, "img", "bandas",mFileName);

                    using (var stream = new FileStream(mPath, FileMode.Create))
                    {
                        PhotoFile.CopyTo(stream);
                    }

                    banda.Photo = "/img/bandas/" + mFileName;
                }

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
        public IActionResult Edit(Banda banda , IFormFile? PhotoFile)
        {
            if (ModelState.IsValid)
            {
                var bandaExistente = _context.Banda.Find(banda.BandaId);
                if (bandaExistente == null) return NotFound();

                bandaExistente.Nombre = banda.Nombre;

                if (PhotoFile != null)
                {
                    // borrar imagen vieja
                    if(bandaExistente.Photo != null)
                    {
                        string mPathExistente = Path.Combine(ImagenFilePath, bandaExistente.Photo.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
                        if (!string.IsNullOrEmpty(mPathExistente))
                        {
                            if (System.IO.File.Exists(mPathExistente))
                                System.IO.File.Delete(mPathExistente);
                        }
                    }

                    string mFileName = Guid.NewGuid() + Path.GetExtension(PhotoFile.FileName);
                    string mPath = Path.Combine(ImagenFilePath, "img", "bandas", mFileName);

                    using (var stream = new FileStream(mPath, FileMode.Create))
                    {
                        PhotoFile.CopyTo(stream);
                    }

                    bandaExistente.Photo = "/img/bandas/" + mFileName;
                }

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

            if (!string.IsNullOrEmpty(banda.Photo))
            {
                string mPathExistente = Path.Combine(ImagenFilePath, banda.Photo.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
                if (System.IO.File.Exists(mPathExistente))
                    System.IO.File.Delete(mPathExistente);
            }

            _context.Banda.Remove(banda);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

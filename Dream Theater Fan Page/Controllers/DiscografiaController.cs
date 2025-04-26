using Microsoft.AspNetCore.Mvc;
using Dream_Theater_Fan_Page.Models;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class DiscografiaController : Controller
    {
        public IActionResult Index()
        {
            var albums = new List<AlbumModel>
            {
                new AlbumModel
                {
                    Title = "Images and Words",
                    Description = "Segundo álbum de estudio lanzado en 1992.",
                    Cover = "/img/discografia/images_and_Words.jpg",
                    AudioSample = "/audio/Metropolis - Part 1 The Miracle and the Sleeper.mp3"
                },
                new AlbumModel
                {
                    Title = "Awake",
                    Description = "Tercer álbum, lanzado en 1994.",
                    Cover = "/img/discografia/Awake.jpg",
                    AudioSample = "/audio/6_00.mp3"
                },
                new AlbumModel
                {
                    Title = "Metropolis Pt. 2: Scenes from a Memory",
                    Description = "Álbum conceptual de 1999.",
                    Cover = "/img/discografia/Scenes_from_a_Memory.jpg",
                    AudioSample = "/audio/The Dance of Eternity.mp3"
                }
            };

            ViewBag.Albums = albums;
            return View();
        }
    }
}

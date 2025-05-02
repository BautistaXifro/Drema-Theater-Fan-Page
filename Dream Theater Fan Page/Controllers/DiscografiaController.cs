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
                    Title = "When Dream and Day Unite",
                    Description = "Álbum debut lanzado en 1989",
                    Cover = "/img/discografia/WDADU.jpg",
                    AudioSample = "/audio/Status Seeker.mp3"
                },
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
                    Title = "Falling Into Infinity",
                    Description = "Cuarto álbum, lanzado en 1997.",
                    Cover = "/img/discografia/Falling_into_Infinity.jpg",
                    AudioSample = "/audio/New Millennium.mp3"
                },
                new AlbumModel
                {
                    Title = "Metropolis Pt. 2: Scenes from a Memory",
                    Description = "Álbum conceptual de 1999.",
                    Cover = "/img/discografia/Scenes_from_a_Memory.jpg",
                    AudioSample = "/audio/The Dance of Eternity.mp3"
                },
                new AlbumModel
                {
                    Title = "Six Degrees of Inner Turbulence",
                    Description = "Álbum semi conceptual de 2002.",
                    Cover = "/img/discografia/Six_Degrees_of_Inner_Turbulence.jpg",
                    AudioSample = "/audio/The Glass Prison.mp3"
                },
                new AlbumModel
                {
                    Title = "Train of Thought",
                    Description = "Septimo álbum, lanzado en 2003.",
                    Cover = "/img/discografia/Train_of_Thought.jpg",
                    AudioSample = "/audio/As I Am.mp3"
                },
                new AlbumModel
                {
                    Title = "Octavarium",
                    Description = "Octavo álbum, lanzado en 2005.",
                    Cover = "/img/discografia/Octavarium.jpg",
                    AudioSample = "/audio/Panic Attack.mp3"
                },
                new AlbumModel
                {
                    Title = "Systematic Chaos",
                    Description = "Noveno álbum, lanzado en 2007.",
                    Cover = "/img/discografia/Systematic_Chaos.jpg",
                    AudioSample = "/audio/Dream Theater - Constant Motion.mp3"
                },
                new AlbumModel
                {
                    Title = "Black Clouds & Silver Linings",
                    Description = "Decimo álbum, lanzado en 2009.",
                    Cover = "/img/discografia/Black_Clouds_&_Silver_Linings.jpg",
                    AudioSample = "/audio/Dream Theater - A Rite Of Passage.mp3"
                },
                new AlbumModel
                {
                    Title = "A Dramatic Turn of Events",
                    Description = "DecimoPrimer álbum, primero album en no contener a Mike Portnoy como baterista. Lanzado en 2011.",
                    Cover = "/img/discografia/DTOE_DT.jpg",
                    AudioSample = "/audio/On The Backs Of Angels.mp3"
                },
                new AlbumModel
                {
                    Title = "Dream Theater",
                    Description = "Homónimo álbum, lanzado en 2013.",
                    Cover = "/img/discografia/DreamTheater.jpg",
                    AudioSample = "/audio/DreamTheater.mp3"
                },
                new AlbumModel
                {
                    Title = "The Astonishing",
                    Description = "Álbum conceptual, el mas largo de su discografia. Lanzado en 2016.",
                    Cover = "/img/discografia/TheAstonishing.png",
                    AudioSample = "/audio/A New Beginning.mp3"
                },
                new AlbumModel
                {
                    Title = "Distance Over Time",
                    Description = "Decimo cuarto álbum, lanzado en 2019.",
                    Cover = "/img/discografia/Distance_Over_Time.png",
                    AudioSample = "/audio/S2N.mp3"
                },
                new AlbumModel
                {
                    Title = "A View from the Top of the World",
                    Description = "Decimo quinto álbum, ultimo disco en tener a Mike Mangini como baterista. Lanzado en 2021.",
                    Cover = "/img/discografia/A_View_from_the_Top_of_the_World.jpg",
                    AudioSample = "/audio/The Alien.mp3"
                },
                new AlbumModel
                {
                    Title = "Parasomnia",
                    Description = "Álbum semi conceptual, regresa Mike Portnoy a la bateria. Lanzado en 2025.",
                    Cover = "/img/discografia/Parasomnia.jpg",
                    AudioSample = "/audio/Night Terror.mp3"
                }
            };

            ViewBag.Albums = albums;
            return View();
        }
    }
}

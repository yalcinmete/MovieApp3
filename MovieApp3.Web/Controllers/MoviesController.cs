using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp3.Web.Data;
using MovieApp3.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp3.Web.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //localhost:17285/movies/details/
        //localhost:17285/movies/details/1
        [HttpGet]
        public IActionResult List(int? id,string q )
        {
            #region AciklamaSatiri
            //var filmListesi = new List<Movie>()
            //{
            //Buraya önceden manuel ekliyorduk.Artık movierepository'den veriyi çekiyoruz.
            //};

            //ViewComponentten yönetiyoruz artık.
            //var turListesi = new List<Genre>()
            //{
            //   new Genre {Name="Macera"},
            //   new Genre {Name="Komedi"},
            //   new Genre {Name="Romantik"},
            //   new Genre {Name="Savaş"},
            //};

            //var model = new MovieGenreViewModel() //Video 19.MovieGenreViewModel İptal.
            //{
            //    Movies = filmListesi,
            //    //Genres = turListesi,
            //};


            //return View("Movies", filmListesi); //View içine yeni bir view ismi yazarak List actionunu Movies view'ine yönlendirebilirsin.
            #endregion

            #region Controllerbilgisinialmak
            //var controller = RouteData.Values["controller"]; 
            //var action = RouteData.Values["action"]; 
            //var genreid = RouteData.Values["id"]; 

            //action'a parametre olarak geçsen(string controller) de gelir.
            #endregion

            #region QueryBilgisiAlmak
            //var kelime = q //(parametreden)
            //var kelime = HttpContext.Request.Query["q"].ToString();
            #endregion


            var movies = MovieRepository.Movies;

            if (id!= null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i => i.Title.ToLower().Contains(q.ToLower()) ||
                i.Description.ToLower().Contains(q.ToLower())).ToList();
            }


            //var turListesi = new List<Genre>()
            //{
            //    new Genre {Name = "Macera"},
            //    new Genre {Name = "Komedi"},
            //    new Genre {Name = "Romantik"},
            //    new Genre {Name = "Savaş"},
            //};

            var model = new MovieGenreViewModel()
            {
                //Movies = filmListesi,
                //Genres = turListesi,
                //Movies = MovieRepository.Movies

                Movies = movies
            };

            //return View("Movies", filmListesi);
            return View("Movies", model);
        }

        //localhost:17285/movies/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        //public IActionResult Create(string Title, string Description, string Director, string ImageUrl, int GenreId)
        public IActionResult Create(Movie m)
        {
            //var m = new Movie()
            //{
            //    Title = Title,
            //    Description = Description,
            //    Director = Director,
            //    ImageUrl = ImageUrl,
            //    GenreId = GenreId
            //};
            if (ModelState.IsValid)
            {
                MovieRepository.Add(m);
                return RedirectToAction("List");
                //return RedirectToAction("Index,Home"); //Overload'ında Action controller da verebiliyorsun.
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(MovieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Edit(m);
                //../movies/details/1
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId }); //burada new ile Anonymous type kullanılmış oldu.(Sınıfı belli olmayan tek seferlik kullanılacak sınıflar) 
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(m);

        }
    }
}

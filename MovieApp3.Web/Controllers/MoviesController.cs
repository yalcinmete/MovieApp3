using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp3.Web.Data;
using MovieApp3.Web.Entity;
using MovieApp3.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp3.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

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


            //var movies = MovieRepository.Movies;

            var movies = _context.Movies.AsQueryable();

            if (id!= null)
            {
                movies = movies.Where(m => m.GenreId == id);
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i => i.Title.ToLower().Contains(q.ToLower()) ||
                i.Description.ToLower().Contains(q.ToLower()));
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

                Movies = movies.ToList(),
            };

            //return View("Movies", filmListesi);
            return View("Movies", model);
        }

        //localhost:17285/movies/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            //return View(MovieRepository.GetById(id));
            return View(_context.Movies.Find(id));
        }


        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
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
                //MovieContext context = new MovieContext();//ctor'u option istiyor.
                //MovieRepository.Add(m);
                _context.Movies.Add(m);
                _context.SaveChanges();
                TempData["Message"] = $"{m.Title} isimli film eklendi.";
                return RedirectToAction("List");
                //return RedirectToAction("Index,Home"); //Overload'ında Action controller da verebiliyorsun.
            }
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            //return View(MovieRepository.GetById(id));
            return View(_context.Movies.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Edit(m);
                _context.Movies.Update(m);
                _context.SaveChanges();

                //../movies/details/1
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId }); //burada new ile Anonymous type kullanılmış oldu.(Sınıfı belli olmayan tek seferlik kullanılacak sınıflar) 
            }
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(m);

        }

        [HttpPost]
        public IActionResult Delete(int MovieId,string Title)
        {
            //MovieRepository.Delete(MovieId);
            var entity = _context.Movies.Find(MovieId);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            //ViewBag.Message = $"{Title} isimli film silindi"; //Actiona yönlendirme işlemi olduğu için ViewBag çalışmaz
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");

        }
    }
}

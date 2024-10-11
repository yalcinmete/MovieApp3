using Microsoft.AspNetCore.Mvc;
using MovieApp3.Web.Data;
using MovieApp3.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp3.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //localhost:17285/movies/details/
        //localhost:17285/movies/details/1
        public IActionResult List(int? id)
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
            //var kelime = HttpContext.Request.Query["q"].ToString();
            #endregion


            var movies = MovieRepository.Movies;

            if (id!= null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
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
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }
    }
}

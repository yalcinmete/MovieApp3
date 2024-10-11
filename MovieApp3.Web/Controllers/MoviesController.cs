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

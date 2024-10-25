using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp3.Web.Data;
using MovieApp3.Web.Models;
using System.Linq;

namespace MovieApp3.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context;

        public AdminController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            ////Daha önce AdminMoviesViewModel ile içerisinde Movie dönüyorduk.
            //return View(new AdminMoviesViewModel
            //{
            //    Movies = _context.Movies.Include(m => m.Genres).ToList()
            //});


            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies
                    .Include(m=>m.Genres)
                    .Select(m=>new AdminMovieViewModel
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ImageUrl = m.ImageUrl,
                        Genres = m.Genres.ToList()
                    })
                    .ToList()
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp3.Web.Data;
using MovieApp3.Web.Entity;
using MovieApp3.Web.Models;
using System.Collections.Generic;
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
        [HttpGet]
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                SelectedGenres = m.Genres
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model , int[] genreIds)
        {
            //var entity = _context.Movies.Find(model.MovieId);
            var entity = _context.Movies.Include("Genres").FirstOrDefault(m=>m.MovieId==model.MovieId);

            if (entity == null) 
            {
                return NotFound();  
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            //entity.Genres = new List<Genre>();
              entity.Genres =genreIds.Select(id=> _context.Genres.FirstOrDefault(i=>i.GenreId==id)).ToList(); 
            
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}

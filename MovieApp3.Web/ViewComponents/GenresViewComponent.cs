using Microsoft.AspNetCore.Mvc;
using MovieApp3.Web.Data;
using MovieApp3.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp3.Web.ViewComponents
{
    public class GenresViewComponent:ViewComponent
    {
        private readonly MovieContext _context;

        public GenresViewComponent(MovieContext context)
        {
            _context = context;

        }
        public IViewComponentResult Invoke()
        {
            //var turListesi = new List<Genre>()
            //{
            //   new Genre {Name="Macera"},
            //   new Genre {Name="Komedi"},
            //   new Genre {Name="Romantik"},
            //   new Genre {Name="Savaş"},
            //};

            //return View(turListesi);

            ViewBag.SelectedGenre = RouteData.Values["id"];
            //return View(GenreRepository.Genres);
            return View(_context.Genres.ToList());
        }
    }
}

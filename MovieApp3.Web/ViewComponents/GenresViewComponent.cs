using Microsoft.AspNetCore.Mvc;
using MovieApp3.Web.Data;
using MovieApp3.Web.Models;
using System.Collections.Generic;

namespace MovieApp3.Web.ViewComponents
{
    public class GenresViewComponent:ViewComponent
    {
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
            return View(GenreRepository.Genres);
        }
    }
}

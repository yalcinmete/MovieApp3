using Microsoft.AspNetCore.Mvc;
using MovieApp3.Web.Data;
using MovieApp3.Web.Models;
using System.Collections.Generic;

namespace MovieApp3.Web.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        //{
        //    return "anasayfa";
        //}
        //public string About()
        //{
        //    return "Hakkımızda";
        //}

        public IActionResult Index()
        {
            //string filmBasligi = "film basliği";
            //string filmAciklama = "filmin açıklaması";
            //string filmYonetmen = "filmin yönetmen adi";
            //string[] oyuncular = { "oyuncu1", "oyuncu2", "oyuncu3", "oyuncu4" };

            //var m = new Movie();
            //m.Title = filmBasligi;
            //m.Description = filmAciklama;
            //m.Director = filmYonetmen;
            //m.Players = oyuncular;
            //m.ImageUrl = "1.jpg";


            var model = new HomePageViewModel
            {
                PopularMovies = MovieRepository.Movies
            };


            return View(model);

            //ViewBag.FilmBasligi = filmBasligi;
            //ViewBag.FilmAciklamasi = filmAciklama;
            //ViewBag.FilmYonetmeni = filmYonetmen;
            //ViewBag.Oyuncular = oyuncular;
        }
        public IActionResult About()
        {
            //ViewComponent ile gönderdik.
            //var turListesi = new List<Genre>()
            //{
            //   new Genre {Name="Macera"},
            //   new Genre {Name="Komedi"},
            //   new Genre {Name="Romantik"},
            //   new Genre {Name="Savaş"},
            //};
            //return View(turListesi);
            return View();
        }

        
    }
}

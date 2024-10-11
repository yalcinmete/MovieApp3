using Microsoft.AspNetCore.Mvc;
using MovieApp3.Web.Models;
using System.Collections.Generic;

namespace MovieApp3.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie
                {
                    Title="film 1",
                    Description="açıklama 1",
                    Director = "Yönetmen 1",
                    Players  = new string[] {"oyuncu 1","oyuncu 2" , "oyuncu 3","oyuncu 4"},
                    ImageUrl  = "1.jpg"
                },
                    
                new Movie
                {
                    Title="film 2",
                    Description="açıklama 2",
                    Director = "Yönetmen 2",
                    Players  = new string[] {"oyuncu 1","oyuncu 2" , "oyuncu 3","oyuncu 4"} ,
                    ImageUrl  = "2.jpg"},
                new Movie
                {
                    Title="film 3",
                    Description="açıklama 3",
                    Director = "Yönetmen 3",
                    Players  = new string[] {"oyuncu 1","oyuncu 2" , "oyuncu 3","oyuncu 4"} , 
                    ImageUrl = "3.jpg"},
                new Movie
                {
                    Title="film 4",
                    Description="açıklama 4",
                    Director = "Yönetmen 4",
                    Players  = new string[] {"oyuncu 1","oyuncu 2" , "oyuncu 3","oyuncu 4"},
                    ImageUrl  = "4.jpg"},
            };

            var turListesi = new List<Genre>()
            {
                new Genre {Name = "Macera"},
                new Genre {Name = "Komedi"},
                new Genre {Name = "Romantik"},
                new Genre {Name = "Savaş"},
            };

            var model = new MovieGenreViewModel()
            {
                Movies = filmListesi,
                Genres = turListesi,
            };

            //return View("Movies", filmListesi);
            return View("Movies", model);
        }
    }
}

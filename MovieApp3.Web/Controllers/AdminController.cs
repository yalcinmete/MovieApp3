using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp3.Web.Data;
using MovieApp3.Web.Entity;
using MovieApp3.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> MovieUpdate(AdminEditMovieViewModel model , int[] genreIds , IFormFile  file)
        {
            //var entity = _context.Movies.Find(model.MovieId);
            var entity = _context.Movies.Include("Genres").FirstOrDefault(m=>m.MovieId==model.MovieId);

            if (entity == null) 
            {
                return NotFound();  
            }

            entity.Title = model.Title;
            entity.Description = model.Description;

            //entity.ImageUrl = model.ImageUrl;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName); // .jpg, .png alır.Dosya uzantısını aldık.
                var filename = string.Format($"{Guid.NewGuid()}{extension}"); // $"yalcin{...} dosya isminin başına yalcin da yazabilirsin
                                                                              //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName); dosya yerine gidip aynı isimli resim bulursa silip tekrar yükler.Veri kaybı oluşmaması için resim isimlerine unique isim vermemiz gerekir yukarıdaki 2 satırda bunu yaptık.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", filename); //Dosyayı kaydedeceği yeri söylüyoruz..Aynı isimli dosya bulursa aynı isimli dosyanın üstüne yazar.Bu nedenle yukarıda dosyabasına newguid verdik.
                entity.ImageUrl = filename;

                using (var stream = new FileStream(path, FileMode.Create)) //Dosyanın kaydedilmesi.
                {
                    await file.CopyToAsync(stream); //Dosyanın kaydedilmesi.Dosyanın kaydeilmesini bekliyoruz. Metot içinde async kullanırsak metotu da asenkron yapmamız gerekiyor (task ekle ).
                }
            }


            //entity.Genres = new List<Genre>();
            entity.Genres =genreIds.Select(id=> _context.Genres.FirstOrDefault(i=>i.GenreId==id)).ToList(); 
            
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult GenreList()
        {
            return View(new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g=>new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count,
                }).ToList(),
            });
        }

        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context
                .Genres
                .Select(g => new AdminGenreEditViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(i => new AdminMovieViewModel
                    {
                        MovieId = i.MovieId,
                        Title = i.Title,
                        ImageUrl = i.ImageUrl,
                    }).ToList()
                }).FirstOrDefault(g => g.GenreId == id);

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }


        [HttpPost]
        public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
        {

            //var entity = _context.Genres.FirstOrDefault(i => i.GenreId == model.GenreId);

            //if (entity == null) 
            //{
            //    return NotFound();
            //}

            //entity.Name= model.Name;

            //_context.SaveChanges();

            //return RedirectToAction("GenreList");   


                var entity = _context.Genres.Include("Movies").FirstOrDefault(i => i.GenreId == model.GenreId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;

                foreach (var id in movieIds)
                {
                    entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId == id));
                }

                _context.SaveChanges();
                return RedirectToAction("GenreList");

        }

        [HttpPost]
        public ActionResult GenreDelete(int genreId)
        {
            var entity = _context.Genres.Find(genreId);
            if (entity != null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("GenreList");
        }

        [HttpPost]
        public ActionResult MovieDelete(int movieId)
        {
            var entity = _context.Movies.Find(movieId);
            if (entity != null)
            {
                _context.Movies.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }

        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            //return View();
            return View(new AdminCreateMovieModel() );
        }

        [HttpPost]
        //public IActionResult MovieCreate(Movie m , int[] genreIds)
        //public IActionResult MovieCreate(AdminCreateMovieModel model , int[] genreIds)
        public IActionResult MovieCreate(AdminCreateMovieModel model ) //model içinde genreIds bilgisi var.
        {

            if (model.Title !=null && model.Title.Contains("@")) 
            {
                ModelState.AddModelError("", "Film başlığı @ işareti içeremez");//Model ile ilişkilendirmek istemeyebilirsin bu sefer hata en üstte (All dediğimiz için) çıkar. 
                //ModelState.AddModelError("Title", "Film başlığı @ işareti içeremez");//Model ile ilişkilendirmek istyebilirsin bu sefer hata model textboxın altında çıkar.
            }

            //if (model.GenreIds.Length == 0) artık dizi olarak değil model içinden geliyor. Boş yani seçilmezse null döner.
            //if (model.GenreIds == null) //artık model içinde kontrol olduğu için modelin içine gidip GenreIds property'e required eklemen yeterli
            //{
            //    ModelState.AddModelError("GenreIds", "En az bir tür seçmelisiniz");
            //}

            if (ModelState.IsValid)
            {
                var entity = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = "no-image.png"
                };

                
                //m.Genres = new List<Genre>(); //Genres bilgisi tanımlı ama null gösteriyordu.Null göstermesin.//movie classının ctor'unda yaptık.
                foreach (var  id in model.GenreIds)
                {
                    entity.Genres.Add(_context.Genres.FirstOrDefault(i => i.GenreId == id));
                }
                _context.Movies.Add(entity);
                _context.SaveChanges();

                return RedirectToAction("MovieList", "Admin");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View(model);  
        }
    }
}

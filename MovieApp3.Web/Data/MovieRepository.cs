using MovieApp3.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp3.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie{
                    MovieId = 1,
                    Title = "Hadi İnşallah",
                    Description = "İşsiz ve aşksız genç kadın bir tanıdık vasıtasıyla yerel bir TV kanalında iş bulur, muhabirliğe başlar. Bu arada kanalın yakışıklı anchorman'i Pekmez'e abayı yakar, yakışıklı adamın sevgili Bayan Kaltak'ı ise yeni düşmanı beller. Bu noktadan sonra ise Operasyon Pekmez harekatını başlatır.",
                    Director = "Ali Taner Baltacı",
                    Players = new string[] {"Büşra Pekin", "Murat Boz" },
                     ImageUrl = "film1.jpg",

                },
                new Movie{
                    MovieId = 2,
                    Title = "Alem-i Cin 4",
                    Description = "Film, Azat ile yaşadığı mutlu evliliğinde bir de bebek bebek bekleyen İrem'in, hamilelik sırasında kabuslar görmeye başlaması sonrası başından geçenleri konu ediniyor. İrem üniversiteden sevgilisi Azat'la evlenmiş, mutlu bir evliliği vardır. Evlilikleri, İrem'in hamile kalmasıyla daha da taçlanmıştır.",
                    Director = "Burak Çelik",
                    Players = new string[] { "Merve Özel", "Onur Aziz Özdemir", "Levent Çakır" },
                    ImageUrl = "film2.jpg",
                },
                new Movie{
                    MovieId = 3,
                    Title = "film 3",
                    Description = "Wind, çocuk yaşlarda babasının yıkımına, sonra da ölümüne neden olan iş insanı Ethem Bey'den intikam almak için yıllar süren bir çalışma içine girmiştir. Wind adıyla internet ortamında hacker olarak var olmayı başarmıştır. Pek çok kişinin korkulu rüyası olmuştur.",
                    Director = "Aykut Taşkın",
                    Players = new string[] {"Hakan Bilgin", "Yosi Mizrahi", "Veysel Demir" },
                    ImageUrl = "film3.jpg",
                },
                 new Movie{
                    MovieId = 1,
                    Title = "Hadi İnşallah",
                    Description = "İşsiz ve aşksız genç kadın bir tanıdık vasıtasıyla yerel bir TV kanalında iş bulur, muhabirliğe başlar. Bu arada kanalın yakışıklı anchorman'i Pekmez'e abayı yakar, yakışıklı adamın sevgili Bayan Kaltak'ı ise yeni düşmanı beller. Bu noktadan sonra ise Operasyon Pekmez harekatını başlatır.",
                    Director = "Ali Taner Baltacı",
                    Players = new string[] {"Büşra Pekin", "Murat Boz" },
                     ImageUrl = "film1.jpg",

                },
                new Movie{
                    MovieId = 2,
                    Title = "Alem-i Cin 4",
                    Description = "Film, Azat ile yaşadığı mutlu evliliğinde bir de bebek bebek bekleyen İrem'in, hamilelik sırasında kabuslar görmeye başlaması sonrası başından geçenleri konu ediniyor. İrem üniversiteden sevgilisi Azat'la evlenmiş, mutlu bir evliliği vardır. Evlilikleri, İrem'in hamile kalmasıyla daha da taçlanmıştır.",
                    Director = "Burak Çelik",
                    Players = new string[] { "Merve Özel", "Onur Aziz Özdemir", "Levent Çakır" },
                    ImageUrl = "film2.jpg",
                },
                new Movie{
                    MovieId = 3,
                    Title = "film 3",
                    Description = "Wind, çocuk yaşlarda babasının yıkımına, sonra da ölümüne neden olan iş insanı Ethem Bey'den intikam almak için yıllar süren bir çalışma içine girmiştir. Wind adıyla internet ortamında hacker olarak var olmayı başarmıştır. Pek çok kişinin korkulu rüyası olmuştur.",
                    Director = "Aykut Taşkın",
                    Players = new string[] {"Hakan Bilgin", "Yosi Mizrahi", "Veysel Demir" },
                    ImageUrl = "film3.jpg",
                },
            };
        }

        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }

        public static void Edit(Movie m)
        {
            foreach (var movie in _movies)
            {
                if (movie.MovieId == m.MovieId)
                {  //Burada title eşit ise atama yap da kontrolü yapabilirsin
                    movie.Title = m.Title;
                    movie.Description = m.Description;
                    movie.Director = m.Director;
                    movie.ImageUrl = m.ImageUrl;
                    movie.GenreId = m.GenreId;
                    break; //10 tane moviden 2.movide bulduysan daha dönme.
                }
            }
        }
        public static void Delete(int MovieId)
        {
            var movie = GetById(MovieId);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }

    }
}

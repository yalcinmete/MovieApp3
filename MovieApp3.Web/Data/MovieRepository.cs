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
                    Title = "Kocan Kadar Konuş",
                    Description = "Efsun üzerinden, bu coğrafyada yaşayan kadınların, daha küçük yaşlarda koca bulmaya programlandıklarını ileri süren yapım 30 yaşına gelmiş olan Efsun'un hayatının kalan kısmını birlikte geçirmeyi hedeflediği gerçek aşkı, sevgiyi, dürüstlüğü arayışını anlatırken, akranı olan kadınlar gibi erkekleri yönlendiremeyen genç kadının imdadına, \"kadınlığın kitabını yazmış\" İzmirli ailesi yetişir. Kendisini güvenilir Türk kadınlarına emanet eden Efsun erkeklerin tüm zaaflarını öğrendikten sonra ise karşısına yıllardır unutamadığı lise aşkı Sinan çıkar! ",
                    Director = "Kıvanç Baruönü",
                    Players = new string[] { "Ezgi Mola", "Murat Yıldırım", "Nevra Serezli" },
                     ImageUrl = "1.jpg",
                     GenreId    =  1

                },
                new Movie{
                    MovieId = 2,
                    Title = "Alem-i Cin 4",
                    Description = "Film, Azat ile yaşadığı mutlu evliliğinde bir de bebek bebek bekleyen İrem'in, hamilelik sırasında kabuslar görmeye başlaması sonrası başından geçenleri konu ediniyor. İrem üniversiteden sevgilisi Azat'la evlenmiş, mutlu bir evliliği vardır. Evlilikleri, İrem'in hamile kalmasıyla daha da taçlanmıştır.",
                    Director = "Burak Çelik",
                    Players = new string[] { "Merve Özel", "Onur Aziz Özdemir", "Levent Çakır" },
                    ImageUrl = "2.jpg",
                     GenreId    =  1
                },
                new Movie{
                    MovieId = 3,
                    Title = "Geri Sayım",
                    Description = "Wind, çocuk yaşlarda babasının yıkımına, sonra da ölümüne neden olan iş insanı Ethem Bey'den intikam almak için yıllar süren bir çalışma içine girmiştir. Wind adıyla internet ortamında hacker olarak var olmayı başarmıştır. Pek çok kişinin korkulu rüyası olmuştur.",
                    Director = "Aykut Taşkın",
                    Players = new string[] {"Hakan Bilgin", "Yosi Mizrahi", "Veysel Demir" },
                    ImageUrl = "3.jpg",
                    GenreId    =  3
                },
                 new Movie{
                    MovieId = 4,
                    Title = "Avatar",
                    Description = "Film Na’vi adlı yok olmak üzere olan bir halkın yaşadığı Pandora adlı gezegende geçiyor. Yarı-felçli bir savaş gazisi olan Jake Sully, kendilerine özgü dilleri ve kültürü olan, barış ve doğa ile örtülü bir çevrede yaşayan Na’vi halkının arasına gönderilir. Gezegendeki değerli enerji kaynaklarını elde etmelerine mani olarak görülen Na’vi halkının arasına sızmakla görevlendirilen Jake, güzel bir Na’vi olan Neytiri tarafından hayatı kurtarılınca her şey değişir.",
                    Director = "James Cameron",
                    Players = new string[] { "Sam Worthington", "Zoë Saldaña" },
                     ImageUrl = "4.jpg",
                     GenreId    =  4

                },
                new Movie{
                    MovieId = 5,
                    Title = "Tehlikeli Sular",
                    Description = "Gerilim. Film, annesi ve onun yeni erkek arkadaşıyla bir açık deniz tatiline çıkan Rose'un, yelkenlilerine bir grup silahlı adamın saldırması sonrası başından geçenleri konu ediniyor. Annesi ve onun erkek arkadaşıyla tekne gezisine çıkan Rose gezileri esnasında Derek'in gizli sırlarını öğrenir.",
                    Director = "John Barr",
                    Players = new string[] { "Eric Dane", "Odeya Rush", "Saffron Burrows" },
                    ImageUrl = "5.jpg",
                    GenreId    =  3
                },
                new Movie{
                    MovieId = 6,
                    Title = "Küçük Prens",
                    Description = "Film, kitabın hikâyesini, yaşlı bir pilot olan anlatıcısıyla yeni tanışan ve ona Küçük Prens ile Sahra çölünde karşılaşmasının hikâyesini anlatan genç bir kız hakkında bilgisayar animasyonlu bir çerçeveleme tekniğiyle stop motion animasyon kullanarak anlatmaktadır. Filmin animasyonu stüdyo Mikros Image tarafından sağlanmıştır.[",
                    Director = "Mark Osborne",
                    Players = new string[] { "Jeff Bridges", "Rachel McAdams", "Paul Rudd" },
                    ImageUrl = "6.jpg",
                    GenreId    =  4
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
                    //movie.GenreId = m.GenreId;
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

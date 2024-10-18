using Microsoft.AspNetCore.Builder;
using MovieApp3.Web.Entity;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieApp3.Web.Data
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate(); //update-database  veritabanı oluşturuldu

            var genres = new List<Genre>()
                        {
                            new Genre {Name = "Macera" , Movies= new List<Movie>() 
                            { 
                                new Movie{
                                Title = "yeni macera filmi 1",
                                Description = "yeni macera filmi 1 açıklama ",
                                 ImageUrl = "1.jpg",
                                 //GenreId    =  genres[0].GenreId

                                },
                                new Movie{
                                    Title = "yeni macera filmi 2",
                                    Description = "yeni macera filmi 2 açıklama",
                                    ImageUrl = "2.jpg",
                                }, 
                            }},
                            new Genre {Name = "Komedi"},
                            new Genre {Name = "Romantik"},
                            new Genre {Name = "Savaş"},
                            new Genre {Name = "Bilim Kurgu"}
                        };

            var movies = new List<Movie>()
                        {
                            new Movie{
                                Title = "Kocan Kadar Konuş",
                                Description = "Efsun üzerinden, bu coğrafyada yaşayan kadınların, daha küçük yaşlarda koca bulmaya programlandıklarını ileri süren yapım 30 yaşına gelmiş olan Efsun'un hayatının kalan kısmını birlikte geçirmeyi hedeflediği gerçek aşkı, sevgiyi, dürüstlüğü arayışını anlatırken, akranı olan kadınlar gibi erkekleri yönlendiremeyen genç kadının imdadına, kadınlığın kitabını yazmış İzmirli ailesi yetişir. ",
                                //Director = "Kıvanç Baruönü",
                                //Players = new string[] { "Ezgi Mola", "Murat Yıldırım", "Nevra Serezli" },
                                 ImageUrl = "1.jpg",
                                 //GenreId    =  genres[0].GenreId
                                 Genre    =  genres[0]

                            },
                            new Movie{
                                Title = "Alem-i Cin 4",
                                Description = "Film, Azat ile yaşadığı mutlu evliliğinde bir de bebek bebek bekleyen İrem'in, hamilelik sırasında kabuslar görmeye başlaması sonrası başından geçenleri konu ediniyor. İrem üniversiteden sevgilisi Azat'la evlenmiş, mutlu bir evliliği vardır. Evlilikleri, İrem'in hamile kalmasıyla daha da taçlanmıştır.",
                                //Director = "Burak Çelik",
                                //Players = new string[] { "Merve Özel", "Onur Aziz Özdemir", "Levent Çakır" },
                                ImageUrl = "2.jpg",
                                 Genre    =  genres[1]
                            },
                            new Movie{
                                Title = "Geri Sayım",
                                Description = "Wind, çocuk yaşlarda babasının yıkımına, sonra da ölümüne neden olan iş insanı Ethem Bey'den intikam almak için yıllar süren bir çalışma içine girmiştir. Wind adıyla internet ortamında hacker olarak var olmayı başarmıştır. Pek çok kişinin korkulu rüyası olmuştur.",
                                //Director = "Aykut Taşkın",
                                //Players = new string[] {"Hakan Bilgin", "Yosi Mizrahi", "Veysel Demir" },
                                ImageUrl = "3.jpg",
                               Genre    =  genres[1]
                            },
                             new Movie{
                                Title = "Avatar",
                                Description = "Film Na’vi adlı yok olmak üzere olan bir halkın yaşadığı Pandora adlı gezegende geçiyor. Yarı-felçli bir savaş gazisi olan Jake Sully, kendilerine özgü dilleri ve kültürü olan, barış ve doğa ile örtülü bir çevrede yaşayan Na’vi halkının arasına gönderilir. Gezegendeki değerli enerji kaynaklarını elde etmelerine mani olarak görülen Na’vi halkının arasına sızmakla görevlendirilen Jake, güzel bir Na’vi olan Neytiri tarafından hayatı kurtarılınca her şey değişir.",
                                //Director = "James Cameron",
                                //Players = new string[] { "Sam Worthington", "Zoë Saldaña" },
                                 ImageUrl = "4.jpg",
                                 Genre    =  genres[2]

                            },
                            new Movie{
                                Title = "Tehlikeli Sular",
                                Description = "Gerilim. Film, annesi ve onun yeni erkek arkadaşıyla bir açık deniz tatiline çıkan Rose'un, yelkenlilerine bir grup silahlı adamın saldırması sonrası başından geçenleri konu ediniyor. Annesi ve onun erkek arkadaşıyla tekne gezisine çıkan Rose gezileri esnasında Derek'in gizli sırlarını öğrenir.",
                                //Director = "John Barr",
                                //Players = new string[] { "Eric Dane", "Odeya Rush", "Saffron Burrows" },
                                ImageUrl = "5.jpg",
                                Genre    =  genres[2]
                            },
                            new Movie{
                                Title = "Küçük Prens",
                                Description = "Film, kitabın hikâyesini, yaşlı bir pilot olan anlatıcısıyla yeni tanışan ve ona Küçük Prens ile Sahra çölünde karşılaşmasının hikâyesini anlatan genç bir kız hakkında bilgisayar animasyonlu bir çerçeveleme tekniğiyle stop motion animasyon kullanarak anlatmaktadır. Filmin animasyonu stüdyo Mikros Image tarafından sağlanmıştır.",
                                //Director = "Mark Osborne",
                                //Players = new string[] { "Jeff Bridges", "Rachel McAdams", "Paul Rudd" },
                                ImageUrl = "6.jpg",
                                Genre    =  genres[3]
                            }
                        };


            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }
                if (context.Movies.Count() == 0 )
                {
                    context.Movies.AddRange(movies);
                }
               
                context.SaveChanges();
            }
        }
    }
}

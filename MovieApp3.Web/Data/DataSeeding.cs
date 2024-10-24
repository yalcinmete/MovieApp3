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
                                 //Genre    =  genres[0]
                                 Genres = new List<Genre> { genres[0], new Genre() { Name="Yeni Tür"}, genres[1] }

                            },
                            new Movie{
                                Title = "Alem-i Cin 4",
                                Description = "Film, Azat ile yaşadığı mutlu evliliğinde bir de bebek bebek bekleyen İrem'in, hamilelik sırasında kabuslar görmeye başlaması sonrası başından geçenleri konu ediniyor. İrem üniversiteden sevgilisi Azat'la evlenmiş, mutlu bir evliliği vardır. Evlilikleri, İrem'in hamile kalmasıyla daha da taçlanmıştır.",
                                //Director = "Burak Çelik",
                                //Players = new string[] { "Merve Özel", "Onur Aziz Özdemir", "Levent Çakır" },
                                ImageUrl = "2.jpg",
                                 //Genre    =  genres[1]
                                 Genres = new List<Genre> { genres[0], genres[2] }
                            },
                            new Movie{
                                Title = "Geri Sayım",
                                Description = "Wind, çocuk yaşlarda babasının yıkımına, sonra da ölümüne neden olan iş insanı Ethem Bey'den intikam almak için yıllar süren bir çalışma içine girmiştir. Wind adıyla internet ortamında hacker olarak var olmayı başarmıştır. Pek çok kişinin korkulu rüyası olmuştur.",
                                //Director = "Aykut Taşkın",
                                //Players = new string[] {"Hakan Bilgin", "Yosi Mizrahi", "Veysel Demir" },
                                ImageUrl = "3.jpg",
                               //Genre    =  genres[1]
                               //Genres = new List<Genre> { genres[0], new Genre() { Name="Yeni Tür"}, genres[1] }
                               Genres = new List<Genre> { genres[1],  genres[3] }

                            },
                             new Movie{
                                Title = "Avatar",
                                Description = "Film Na’vi adlı yok olmak üzere olan bir halkın yaşadığı Pandora adlı gezegende geçiyor. Yarı-felçli bir savaş gazisi olan Jake Sully, kendilerine özgü dilleri ve kültürü olan, barış ve doğa ile örtülü bir çevrede yaşayan Na’vi halkının arasına gönderilir. Gezegendeki değerli enerji kaynaklarını elde etmelerine mani olarak görülen Na’vi halkının arasına sızmakla görevlendirilen Jake, güzel bir Na’vi olan Neytiri tarafından hayatı kurtarılınca her şey değişir.",
                                //Director = "James Cameron",
                                //Players = new string[] { "Sam Worthington", "Zoë Saldaña" },
                                 ImageUrl = "4.jpg",
                                 //Genre    =  genres[2]
                                 Genres = new List<Genre> { genres[0],  genres[1] }

                            },
                            new Movie{
                                Title = "Tehlikeli Sular",
                                Description = "Gerilim. Film, annesi ve onun yeni erkek arkadaşıyla bir açık deniz tatiline çıkan Rose'un, yelkenlilerine bir grup silahlı adamın saldırması sonrası başından geçenleri konu ediniyor. Annesi ve onun erkek arkadaşıyla tekne gezisine çıkan Rose gezileri esnasında Derek'in gizli sırlarını öğrenir.",
                                //Director = "John Barr",
                                //Players = new string[] { "Eric Dane", "Odeya Rush", "Saffron Burrows" },
                                ImageUrl = "5.jpg",
                                //Genre    =  genres[2]
                                Genres = new List<Genre> { genres[2], genres[4] }
                            },
                            new Movie{
                                Title = "Küçük Prens",
                                Description = "Film, kitabın hikâyesini, yaşlı bir pilot olan anlatıcısıyla yeni tanışan ve ona Küçük Prens ile Sahra çölünde karşılaşmasının hikâyesini anlatan genç bir kız hakkında bilgisayar animasyonlu bir çerçeveleme tekniğiyle stop motion animasyon kullanarak anlatmaktadır. Filmin animasyonu stüdyo Mikros Image tarafından sağlanmıştır.",
                                //Director = "Mark Osborne",
                                //Players = new string[] { "Jeff Bridges", "Rachel McAdams", "Paul Rudd" },
                                ImageUrl = "6.jpg",
                                //Genre    =  genres[3]
                                Genres = new List<Genre> { genres[1], genres[2] }
                            }
                        };


            var users = new List<User>()
            {
                new User(){Username="usera",Email="usera@gmail.com",Password="1234",ImageUrl="person1.jpg"},
                new User(){Username="userb",Email="userb@gmail.com",Password="1234",ImageUrl="person2.jpg"},
                new User(){Username="userc",Email="userc@gmail.com",Password="1234",ImageUrl="person3.jpg"},
                new User(){Username="userd",Email="userd@gmail.com",Password="1234",ImageUrl="person4.jpg"}
            };


            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Personel 1",
                    Biography = "Tanıtım 1",
                    User = users[0]
                },
                new Person()
                {
                    Name = "Personel 2",
                    Biography = "tanıtım 2",
                    User = users[1]
                }
            };

            var crews = new List<Crew>()
            {
                new Crew() { Movie=movies[0] , Person = people[0],Job="Yönetmen" },
                new Crew() { Movie=movies[0] , Person = people[1],Job="Yönetmen yardımcısı" }
            };


            var casts = new List<Cast>()
            {
                new Cast() { Movie = movies[0], Person = people[0],Name="Oyuncu Adı 1", Character="Karakter 1"},
                new Cast() { Movie = movies[0], Person = people[1],Name="Oyuncu Adı 2", Character="Karakter 2"}
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

                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }

                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }

                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }

                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }

                context.SaveChanges();
            }
        }
    }
}

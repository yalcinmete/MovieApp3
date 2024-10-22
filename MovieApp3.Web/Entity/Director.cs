using System;

namespace MovieApp3.Web.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public Person Person { get; set; }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Imdb { get; set; }
        public string HomePage { get; set; }
        public string PlaceOfBirth { get; set; }

        //User kullanıcısı olmalı Navigation propertysi bunu da sağlamış olur.
        public User User { get; set; }
        public int UserId { get; set; } //foreign key, unique key yukarıda User sınıfı içerisinde Person da oluşturduğun için UserId unique key de olmuş oluyor. İlişki kurulduğu için.

    }

}

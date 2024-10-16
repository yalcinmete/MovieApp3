using System.ComponentModel.DataAnnotations;

namespace MovieApp3.Web.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

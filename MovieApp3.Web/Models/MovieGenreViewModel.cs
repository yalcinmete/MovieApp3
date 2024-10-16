using MovieApp3.Web.Entity;
using System.Collections.Generic;

namespace MovieApp3.Web.Models
{
    public class MovieGenreViewModel
    {

        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}

using MovieApp3.Web.Entity;
using System.Collections.Generic;

namespace MovieApp3.Web.Models
{
    public class AdminMoviesViewModel
    {
        //public List<Movie> Movies { get; set; }
        public List<AdminMovieViewModel> Movies { get; set; } //Açıklama bilgisi gelmesin istedik
    }

    public class AdminMovieViewModel //Açıklama bilgisi gelmesin istedik özelleştirilmiş class oluşturduk.
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }
}

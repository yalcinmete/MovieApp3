using MovieApp3.Web.Entity;
using MovieApp3.Web.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    public class AdminCreateMovieModel 
    {
        [Display(Name ="Film Adı")]
        [Required(ErrorMessage ="film adı girmelisiniz")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Film adı için 3-50 karakter girmelisiniz")]
        public string Title { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage = "film açıklama girmelisiniz")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklama için 10-3000 karakter girmelisiniz")]
        public string Description { get; set; }//Veritabanında description zorunlu alan değil ama model sayesinde zorunlu hale getirebiliyoruz.

        [Required(ErrorMessage = "En az bir tür seçmelisiniz")]
        public int[] GenreIds { get; set; } //Hata mesajını model olarak ekranda gösterebilmek için oluşturduk.

        public bool IsClassic { get; set; }

        [ClassicMovie(1950)]
        [DataType(DataType.Date)] //Html 5 kontrolu yapar.
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
    }

    public class AdminEditMovieViewModel
    {
        public int MovieId { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage = "film adı girmelisiniz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Film adı için 3-50 karakter girmelisiniz")]
        public string Title { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage = "film açıklama girmelisiniz")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklama için 10-3000 karakter girmelisiniz")]

        public string Description { get; set; }//Veritabanında description zorunlu alan değil ama model sayesinde zorunlu hale getirebiliyoruz.
        public string ImageUrl { get; set; }

        //public List<Genre> SelectedGenres { get; set; } //Daha önceden model içinde GenreIds eklemiştik.Artık GenreIds üzerinden işimizi yürütebiliriz.
        [Required(ErrorMessage = "En az bir tür seçmelisiniz")]
        public int[] GenreIds { get; set; } 
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp3.Web.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "film başlığı eklemelisiniz")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "film başlığı 5-10 karakter aralığında olmalıdır.")]
        public string Title { get; set; } //null
        [Required(ErrorMessage = "film açıklaması eklemelisiniz")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Players { get; set; }
        [Required]
        public string ImageUrl { get; set; } //string değer boş değer için null alır
        [Required]
        public int? GenreId { get; set; } //int boş değer için 0 alır.Required demiş olsak bile boş iken 0 değeri atandığı için Required işlevsiz olur. Bu nedenle int? diyip boş ise null atansın diyoruz.
    }
}

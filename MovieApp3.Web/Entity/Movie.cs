using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp3.Web.Entity
{
    public class Movie
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)] //SQL tarafından oluşturulan Otomatik id'yi kapatır.Bu durumda manuel olarak id vermek gerekir.
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; } //null
        [MaxLength(500)]
        public string Description { get; set; }
        //public string Director { get; set; }
        //public string[] Players { get; set; }
        public string ImageUrl { get; set; } //string değer boş değer için null alır
        [Required]
        public int? GenreId { get; set; } //int boş değer için 0 alır.Required demiş olsak bile boş iken 0 değeri atandığı için Required işlevsiz olur. Bu nedenle int? diyip boş ise null atansın diyoruz.
    }
}

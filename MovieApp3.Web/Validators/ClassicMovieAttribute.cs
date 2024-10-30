using MovieApp3.Web.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace MovieApp3.Web.Validators
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }
        public int Year { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (AdminCreateMovieModel)validationContext.ObjectInstance; //Bunun yerine veritabanına select atarak da bu bilgileri alabilirsin. 
            var releaseYear = ((DateTime)value).Year;

            if (movie.IsClassic && releaseYear > Year)
            {
                return new ValidationResult($"Klasik film için {Year} ve öncesi değer girmelisiniz");
            }
            return ValidationResult.Success;
        }
    }
}

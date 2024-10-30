using System.ComponentModel.DataAnnotations;

namespace MovieApp3.Web.Validators
{
    public class EmailProvidersAttribute:ValidationAttribute
    {
        //Diğer custom validation(birthdate) true false döndürüyordu bu örnekte validationresult döndürelim :
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = "";
            if (value != null)
            {
                email = value.ToString();
            }
            if (email.EndsWith("@gmail.com") || email.EndsWith("@hotmail.com"))
            {
                return ValidationResult.Success;

            }
            return new ValidationResult("hatalı eposta sunucusu");
        }
    }
}

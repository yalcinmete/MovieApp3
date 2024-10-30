using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp3.Web.Validators
{
    public class BirthDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) //Textbox'a girilen nesne (name değeri) value'e atanır.
        {
            DateTime datetime = Convert.ToDateTime(value);
            return datetime <= DateTime.Now;
        }
    }
}

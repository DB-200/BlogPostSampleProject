using Books.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.ValidationAttributes
{
    public class BookTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (BookForCreationDto)validationContext.ObjectInstance;
            if (book.Title.Trim().ToUpper() == book.Description.Trim().ToUpper())
            {
                return new ValidationResult(ErrorMessage,
                                                   new[] { nameof(BookForCreationDto) });
            }

            return ValidationResult.Success;
        }
    }
}






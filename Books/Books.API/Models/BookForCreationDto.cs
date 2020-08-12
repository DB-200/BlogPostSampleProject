using Books.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    [BookTitleMustBeDifferentFromDescription(ErrorMessage = "The title and description cannot be the same!")]
    public class BookForCreationDto //: IValidatableObject
    {
        [Required(ErrorMessage = "The title of the book is required.")]
        [MaxLength(512, ErrorMessage ="The book's {0} should not have more than {1} characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="The author of the book is required.")]
        [MaxLength(256, ErrorMessage = "The book's {0} should not have more than {1} characters.")]
        public string Author { get; set; }

        [MaxLength(1024, ErrorMessage = "The book's {0} should not have more than {1} characters.")]
        public string Description { get; set; }

        [MaxLength(256, ErrorMessage = "The book's genre should not have more than 256 characters.")]
        public string Genre { get; set; }

        // for adding a book with quotations at the same time
        public ICollection<QuoteForCreationDto> Quotes { get; set; } = 
                                new List<QuoteForCreationDto>();

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title.Trim().ToUpper() == Description.Trim().ToUpper())
        //    {
        //        yield return new ValidationResult("The Title and Description of the book cannot be the same.",
        //                                           new[] { "BookForCreationDto" });
        //    }
        //}
    }
}





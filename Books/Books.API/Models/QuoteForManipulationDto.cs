using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public abstract class QuoteForManipulationDto
    {
        [Required(ErrorMessage = "You need to provide a quote.")]
        [MaxLength(1024)]
        public string Quote { get; set; }

        [MaxLength(1024, ErrorMessage = "The length of the {0} field must not exceed {1} characters.")]
        public virtual string Notes { get; set; }
    } 
}







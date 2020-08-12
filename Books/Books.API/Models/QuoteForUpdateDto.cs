using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class QuoteForUpdateDto : QuoteForManipulationDto
    {
        [Required(ErrorMessage = "You need to provide information in the Notes field.")]
        public override string Notes { get => base.Notes; set => base.Notes = value; }
    }
}



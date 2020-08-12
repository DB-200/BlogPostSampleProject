using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string Author { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Genre { get; set; }

        public ICollection<Quotation> Quotes { get; set; } = new List<Quotation>();
    }
}

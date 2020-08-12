using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Entities
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Quote { get; set; }
        
        [MaxLength(1024)]
        public string Notes { get; set; }

        // navigation to parent graph
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}

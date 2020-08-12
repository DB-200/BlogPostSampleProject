using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public int NumberOfQuotes
        {
            get
            {
                return Quotes.Count;
            }
        }
        public ICollection<QuoteDto> Quotes { get; set; } = new List<QuoteDto>();
    }
}

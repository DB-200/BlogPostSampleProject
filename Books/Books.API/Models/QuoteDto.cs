using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class QuoteDto
    {
        public int Id { get; set; }
        public string Quote { get; set; }
        public string Notes { get; set; }
    }
}

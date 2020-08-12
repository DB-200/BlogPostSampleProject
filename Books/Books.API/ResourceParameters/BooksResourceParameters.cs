using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.ResourceParameters
{
    public class BooksResourceParameters : ISearchQueryParameter
    {
        public string SearchQuery { get; set; }
        public string Genre { get; set; }
    }
}





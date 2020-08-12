using Books.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API
{
    public class BooksDataStore
    {
        public static BooksDataStore Current { get; } = new BooksDataStore();
        public List<BookDto> Books { get; set; }

        public BooksDataStore()
        {
            Books = new List<BookDto>()
            {
                new BookDto()
                {
                    Id = 1,
                    Title="Great Expectations",
                    Author = "Charles Dickens",
                    Description="",
                    Quotes = new List<QuoteDto>()
                    {
                        new QuoteDto()
                        {
                            Id = 1,
                            Quote ="You are in every line I have ever read.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 2,
                            Quote="Spring is the time of year when it is summer in the sun and winter in the shade.",
                            Notes = ""
                        }
                    }
                },
                new BookDto()
                {
                    Id = 2,
                    Title="Animal Farm",
                    Author="George Orwell",
                    Description="",
                    Quotes = new List<QuoteDto>()
                    {
                        new QuoteDto()
                        {                                        
                            Id = 1,
                            Quote="All animals are equal, but some animals are more equal than others.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 2,
                            Quote = "Four legs good, two legs bad.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 3,
                            Quote = "This work was strictly voluntary, but any animal who absented himself from it would have his rations reduced by half.",
                            Notes = ""
                        }
                    }
                },
                new BookDto()
                {
                    Id = 3,
                    Title="The Maltese Falcon",
                    Author="Dashiell Hammett",
                    Description="",
                     Quotes = new List<QuoteDto>()
                    {
                        new QuoteDto()
                        {
                            Id = 1,
                            Quote=" I wanted it, and I'm not a man that's easily discouraged when he wants something.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 2,
                            Quote = "You know how to do things ... you'll land on your feet in the end.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 3,
                            Quote = "The cheaper the crook, the gaudier the patter.",
                            Notes = ""
                        }
                    }
                },
                new BookDto()
                {
                    Id = 4,
                    Title="A Room with a View",
                    Author="E M Forster",
                    Description="",
                     Quotes = new List<QuoteDto>()
                    {
                        new QuoteDto()
                        {
                            Id = 1,
                            Quote="Life is easy to chronicle, but bewildering to practice.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 2,
                            Quote = "Of course he despised the world as a whole; every thoughtful man should; it is almost a test of refinement.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 3,
                            Quote = "The world is certainly full of beautiful things, if only I could come across them.",
                            Notes = ""
                        }
                    }
                },
                new BookDto()
                {
                    Id = 5,
                    Title="To Kill a Mockingbird",
                    Author="Harper Lee",
                    Description="",
                    Quotes = new List<QuoteDto>()
                    {
                        new QuoteDto()
                        {
                            Id = 1,
                            Quote="You never really understand a person until you consider things from his point of view... Until you climb inside of his skin and walk around in it.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 2,
                            Quote = "People generally see what they look for, and hear what they listen for.",
                            Notes = ""
                        },
                        new QuoteDto()
                        {
                            Id = 3,
                            Quote = "Lawyers, I suppose were once children, too.",
                            Notes = ""
                        }
                    }
                }

            };
        }
    }
}

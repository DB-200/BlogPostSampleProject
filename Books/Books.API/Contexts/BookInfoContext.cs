using Books.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Contexts
{
    public class BookInfoContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        public BookInfoContext(DbContextOptions<BookInfoContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Manually construct model as required, esp. when conventions 
            // are not adequate or you want to be explicit
            // Seed Data... 
            // Book data...
            #region AddBookData
            modelBuilder.Entity<Book>()
                .HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Great Expectations",
                    Author = "Charles Dickens",
                    Description = "",
                    Genre=""
                },
                new Book()
                {
                    Id = 2,
                    Title = "Animal Farm",
                    Author = "George Orwell",
                    Description = "",
                    Genre = ""
                },
                new Book()
                {
                    Id = 3,
                    Title = "The Maltese Falcon",
                    Author = "Dashiell Hammett",
                    Description = "",
                    Genre = ""
                }, 
                new Book()
                {
                    Id = 4,
                    Title = "A Room with a View",
                    Author = "E M Forster",
                    Description = "",
                    Genre = ""
                },
                new Book()
                {
                    Id = 5,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "",
                    Genre = ""
                }
                );
            #endregion

            // add quote data... 
            #region AddQuotesData
            modelBuilder.Entity<Quotation>().HasData(
                new Quotation
                {
                    Id = 1,
                    BookId = 1,
                    Quote = "You are in every line I have ever read.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 2,
                    BookId = 1,
                    Quote = "Spring is the time of year when it is summer in the sun and winter in the shade.",
                    Notes = ""
                },

                // BookId 2
                new Quotation
                {
                    Id = 3,
                    BookId = 2,
                    Quote = "All animals are equal, but some animals are more equal than others.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 4,
                    BookId = 2,
                    Quote = "Four legs good, two legs bad.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 5,
                    BookId = 2,
                    Quote = "This work was strictly voluntary, but any animal who absented himself from it would have his rations reduced by half.",
                    Notes = ""
                },

                // BookId 3
                new Quotation
                {
                    Id = 6,
                    BookId = 3,
                    Quote = " I wanted it, and I'm not a man that's easily discouraged when he wants something.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 7,
                    BookId = 3,
                    Quote = "You know how to do things ... you'll land on your feet in the end.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 8,
                    BookId = 3,
                    Quote = "The cheaper the crook, the gaudier the patter.",
                    Notes = ""
                },

                // BookId 4
                new Quotation
                {
                    Id = 9,
                    BookId = 4,
                    Quote = "Life is easy to chronicle, but bewildering to practice.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 10,
                    BookId = 4,
                    Quote = "Of course he despised the world as a whole; every thoughtful man should; it is almost a test of refinement.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 11,
                    BookId = 4,
                    Quote = "The world is certainly full of beautiful things, if only I could come across them.",
                    Notes = ""
                },

                // Book Id 5
                new Quotation
                {
                    Id = 12,
                    BookId = 5,
                    Quote = "You never really understand a person until you consider things from his point of view... Until you climb inside of his skin and walk around in it.",
                    Notes = ""
                },
                new Quotation
                {
                    Id = 13,
                    BookId = 5,
                    Quote = "People generally see what they look for, and hear what they listen for.",
                    Notes = ""
                },
                new Quotation 
                {
                    Id = 14,
                    BookId = 5,
                    Quote = "Lawyers, I suppose were once children, too.",
                    Notes = ""
                }
                );
#endregion
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

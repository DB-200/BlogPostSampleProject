using Books.API.Contexts;
using Books.API.Entities;
using Books.API.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public class BookInfoRepository : IBookInfoRepository
    {
        private readonly BookInfoContext _context;

        public BookInfoRepository(BookInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof (context));
        }

        public void AddQuoteForBook(int bookId, Quotation quote)
        {
            var book = GetBook(bookId, false);
            book.Quotes.Add(quote);

        }

        public void UpdateBook(Book book)
        {
            // 
        }

        public bool BookExists(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }

        public bool BookHasQuotations(int bookId)
        {
            return _context.Quotations.Any(q => q.BookId == bookId);
        }

        public void DeleteBook(Book book)
        {
            _context.Remove(book);
        }

        public void DeleteQuote(Quotation quote)
        {
            _context.Quotations.Remove(quote);
        }

        public Book GetBook(int bookId, bool includeQuotations)
        {
            if (includeQuotations)
            {
                return _context.Books.Include(b => b.Quotes).Where(b => b.Id == bookId).FirstOrDefault();
            }
            return _context.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.OrderBy(o => o.Title).ToList(); //.ToList() ensures query executed at this time
        }

        public IEnumerable<Book> GetBooks(IEnumerable<int> bookIds)
        {
            if (bookIds == null)
            {
                throw new ArgumentNullException(nameof(bookIds));
            }

            return _context.Books.Where(a => bookIds.Contains(a.Id))
                .OrderBy(o => o.Title)
                .ToList();
        }

        public IEnumerable<Book> GetBooks(BooksResourceParameters booksResourceParameters)
        {
            if (string.IsNullOrWhiteSpace(booksResourceParameters.Genre) 
                                    && string.IsNullOrWhiteSpace(booksResourceParameters.SearchQuery))
                return GetBooks();

            var booksToQuery = _context.Books as IQueryable<Book>;

            if (!string.IsNullOrWhiteSpace(booksResourceParameters.Genre)) {
                var genre = booksResourceParameters.Genre.Trim();
                booksToQuery = booksToQuery.Where(b => b.Genre == genre);
            }

            if (!string.IsNullOrWhiteSpace(booksResourceParameters.SearchQuery))
            {
                var searchQuery = booksResourceParameters.SearchQuery.Trim();
                booksToQuery = booksToQuery.Where(b =>
                    b.Author.Contains(searchQuery) ||
                    b.Description.Contains(searchQuery) ||
                    b.Genre.Contains(searchQuery) ||
                    b.Title.Contains(searchQuery)
                );
            }

            return booksToQuery.ToList();
        }

        public Quotation GetQuotationForBook(int bookId, int quoteId)
        {
            return _context.Quotations.Where(q => q.BookId == bookId && q.Id == quoteId).FirstOrDefault();
        }

        public IEnumerable<Quotation> GetQuotationsForBook(int bookId)
        {
            return _context.Quotations.Where(q => q.BookId == bookId).ToList();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            // if the api consumer creates IDs, that 
            // can be implemented here

            _context.Books.Add(book);
        }
      

        public void UpdateQuoteForBook(int bookId, Quotation quote)
        {
            // no implementation on this as we're
            // tracking changes via the DbContext via the controller
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}


using Books.API.Entities;
using Books.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public interface IBookInfoRepository
    {
        IEnumerable<Book> GetBooks();

        IEnumerable<Book> GetBooks(BooksResourceParameters booksResourceParameters);

        IEnumerable<Book> GetBooks(IEnumerable<int> bookIds);

        Book GetBook(int bookId, bool includeQuotations);

        IEnumerable<Quotation> GetQuotationsForBook(int bookId);

        Quotation GetQuotationForBook(int bookId, int quoteId);

        bool BookExists(int bookId);

        void AddQuoteForBook(int bookId, Quotation quote);

        void AddBook(Book book);

        bool Save();

        void UpdateQuoteForBook(int bookId, Quotation quote);

        void DeleteQuote(Quotation quote);

        void DeleteBook(Book book);

        bool BookHasQuotations(int bookId);

        void UpdateBook(Book book);
    }
}



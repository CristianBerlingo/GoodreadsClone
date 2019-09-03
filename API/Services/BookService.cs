using System.Collections.Generic;
using System.Linq;
using GoodreadsCloneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Services 
{
    public class BookService : IBookService
    {

        private readonly IGoodreadsCloneContext _context;

        public BookService (IGoodreadsCloneContext context) 
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            var books = _context.Book.AsNoTracking().ToList();

            return books;
        }

        public Book GetById(int id)
        {
            var book = _context.Book.AsNoTracking().FirstOrDefault(b => b.Id == id);

            return book;
        }

        public Book GetBookByISBN(string isbn)
        {
            var book = _context.Book.AsNoTracking().FirstOrDefault(b => b.Isbn == isbn);
            
            return book;
        }
    }

}
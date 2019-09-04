using System;
using System.Collections.Generic;
using System.Linq;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Services 
{
    public class BookService : IBaseService<Book>
    {

        private readonly IGoodreadsCloneContext _context;

        public BookService (IGoodreadsCloneContext context) 
        {
            _context = context;
        }

        public List<Book> Get()
        {
            var books = _context.Book.AsNoTracking().ToList();

            return books;
        }

        public Book GetById(int id)
        {
            var book = _context.Book.AsNoTracking().FirstOrDefault(b => b.Id == id);

            return book;
        }

        public void Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public void Delete (int id)
        {
            Book book = _context.Book.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                _context.Book.Attach(book);
                _context.Book.Remove(book);
                _context.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            _context.Book.Update(book);
            _context.SaveChanges();
        }
    }

}
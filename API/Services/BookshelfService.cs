using System.Collections.Generic;
using System.Linq;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Services
{
    public class BookshelfService : IBaseService<Bookshelf>
    {

        private readonly IGoodreadsCloneContext _context;

        public BookshelfService(IGoodreadsCloneContext context)
        {
            _context = context;
        }

        public void Create(Bookshelf bookshelf)
        {
            _context.Add(bookshelf);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Bookshelf bookshelf = _context.Bookshelf.Include(bs => bs.BookshelfBook).FirstOrDefault(b => b.Id == id);
            if(bookshelf != null)
            {
                _context.BookshelfBook.RemoveRange(bookshelf.BookshelfBook);

                _context.Bookshelf.Attach(bookshelf);
                _context.Bookshelf.Remove(bookshelf);
                _context.SaveChanges();
            }
        }

        public List<Bookshelf> Get()
        {
            var bookshelf = _context.Bookshelf.AsNoTracking().ToList();

            return bookshelf;
        }

        public Bookshelf GetById(int id)
        {
            var bookshelf = _context.Bookshelf.AsNoTracking().FirstOrDefault(b => b.Id == id);

            return bookshelf;
        }

        public void Update(Bookshelf bookshelf)
        {
            _context.Bookshelf.Update(bookshelf);
            _context.SaveChanges();
        }
    }
}
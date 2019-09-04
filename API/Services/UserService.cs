using System.Collections.Generic;
using System.Linq;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Services
{
    internal class UserService : IBaseService<User>
    {

        private readonly IGoodreadsCloneContext _context;

        public UserService(IGoodreadsCloneContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _context.User.Include(u => u.Bookshelf)
                .ThenInclude(bs => bs.BookshelfBook)
                .Include(u => u.Review)
                .FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                foreach (var bookshelf in user.Bookshelf)
                {
                    _context.BookshelfBook.RemoveRange(bookshelf.BookshelfBook);
                }
                _context.Bookshelf.RemoveRange(user.Bookshelf);
                _context.Review.RemoveRange(user.Review);
                
                _context.User.Attach(user);
                _context.User.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> Get()
        {
            return _context.User.AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return _context.User.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
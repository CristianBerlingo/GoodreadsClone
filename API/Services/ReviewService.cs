using System.Collections.Generic;
using System.Linq;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Services
{
    public class ReviewService : IBaseService<Review>
    {
        private readonly IGoodreadsCloneContext _context;

        public ReviewService (IGoodreadsCloneContext context) 
        {
            _context = context;
        }

        public void Create(Review review)
        {
            _context.Review.Add(review);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Review review = _context.Review.FirstOrDefault(r => r.Id == id);
            if(review != null)
            {
                _context.Review.Attach(review);
                _context.Review.Remove(review);
                _context.SaveChanges();
            }
        }

        public List<Review> Get()
        {
            return _context.Review.AsNoTracking().ToList();
        }

        public Review GetById(int id)
        {
            return _context.Review.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public void Update(Review review)
        {
            _context.Review.Update(review);
            _context.SaveChanges();
        }
    }
}
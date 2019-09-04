using GoodreadsCloneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Persistence
{
    public interface IGoodreadsCloneContext: IDbContext
    {
        DbSet<Book> Book { get; set; }
        DbSet<Bookshelf> Bookshelf { get; set; }
        DbSet<BookshelfBook> BookshelfBook { get; set; }
        DbSet<Review> Review { get; set; }
        DbSet<User> User { get; set; }
        
    }
}
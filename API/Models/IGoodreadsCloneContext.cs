using Microsoft.EntityFrameworkCore;

namespace GoodreadsCloneAPI.Models
{
    public interface IGoodreadsCloneContext: IDbContext
    {
        DbSet<Book> Book { get; set; }
        
    }
}
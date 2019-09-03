using System.Collections.Generic;
using System.Linq;
using GoodreadsCloneAPI.Models;

namespace GoodreadsCloneAPI.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();

        Book GetById(int id);

        Book GetBookByISBN(string isbn);
    }
}
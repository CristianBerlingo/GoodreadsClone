using System;
using System.Collections.Generic;

namespace GoodreadsCloneAPI.Models
{
    public partial class Bookshelf
    {
        public Bookshelf()
        {
            BookshelfBook = new HashSet<BookshelfBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<BookshelfBook> BookshelfBook { get; set; }
    }
}

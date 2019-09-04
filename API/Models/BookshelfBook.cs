using System;
using System.Collections.Generic;

namespace GoodreadsCloneAPI.Models
{
    public partial class BookshelfBook
    {
        public int BookshelfId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Bookshelf Bookshelf { get; set; }
    }
}

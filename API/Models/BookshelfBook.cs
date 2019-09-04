using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodreadsCloneAPI.Models
{
    public partial class BookshelfBook
    {
        [Required]
        public int BookshelfId { get; set; }
        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Bookshelf Bookshelf { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodreadsCloneAPI.Models
{
    public partial class Bookshelf
    {
        public Bookshelf()
        {
            BookshelfBook = new HashSet<BookshelfBook>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage="Name length can't be more than 200")]
        public string Name { get; set; }
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<BookshelfBook> BookshelfBook { get; set; }
    }
}

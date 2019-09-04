using System;
using System.Collections.Generic;

namespace GoodreadsCloneAPI.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string TextReview { get; set; }
        public int Rating { get; set; }
        public DateTime Published { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}

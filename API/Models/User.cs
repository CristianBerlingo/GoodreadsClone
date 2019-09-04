using System;
using System.Collections.Generic;

namespace GoodreadsCloneAPI.Models
{
    public partial class User
    {
        public User()
        {
            Bookshelf = new HashSet<Bookshelf>();
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Bookshelf> Bookshelf { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}

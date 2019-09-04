using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(200, ErrorMessage="Firstname length can't be more than 200")]
        public string FirstName { get; set; }
        [StringLength(200, ErrorMessage="Lastname length can't be more than 200")]

        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Bookshelf> Bookshelf { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}

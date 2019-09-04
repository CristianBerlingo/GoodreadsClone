using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodreadsCloneAPI.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string TextReview { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public DateTime Published { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}

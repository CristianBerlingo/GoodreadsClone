using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodreadsCloneAPI.Models
{
    public partial class Book
    {
        public Book()
        {
            BookshelfBook = new HashSet<BookshelfBook>();
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        [Range(0, 5)]
        public decimal AverageRating { get; set; }
        [Required]
        [StringLength(13, ErrorMessage="ISBN length can't be more than 13 characters")]
        public string Isbn { get; set; }
        [Required]
        public short? NumPages { get; set; }
        [Required]
        public int RatingsCount { get; set; }
        [Required]
        public int TextReviewsCount { get; set; }

        public ICollection<BookshelfBook> BookshelfBook { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}

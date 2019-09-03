using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoodreadsCloneAPI.Models
{
    public partial class GoodreadsCloneContext : DbContext, IGoodreadsCloneContext
    {
        public GoodreadsCloneContext()
        {
        }

        public GoodreadsCloneContext(DbContextOptions<GoodreadsCloneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("SERVER=localhost;DATABASE=GoodreadsClone;UID=sa;PWD=Piazzolla2019");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Authors)
                    .IsRequired()
                    .HasColumnName("authors")
                    .IsUnicode(false);

                entity.Property(e => e.AverageRating)
                    .HasColumnName("average_rating")
                    .HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NumPages).HasColumnName("num_pages");

                entity.Property(e => e.RatingsCount).HasColumnName("ratings_count");

                entity.Property(e => e.TextReviewsCount).HasColumnName("text_reviews_count");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .IsUnicode(false);
            });
        }
    }
}

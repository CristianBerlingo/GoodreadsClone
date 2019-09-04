using System;
using GoodreadsCloneAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoodreadsCloneAPI.Persistence
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
        public virtual DbSet<Bookshelf> Bookshelf { get; set; }
        public virtual DbSet<BookshelfBook> BookshelfBook { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<User> User { get; set; }

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

            modelBuilder.Entity<Bookshelf>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookshelf)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookshelfUser");
            });

            modelBuilder.Entity<BookshelfBook>(entity =>
            {
                entity.HasKey(e => new { e.BookshelfId, e.BookId });

                entity.Property(e => e.BookshelfId).HasColumnName("bookshelf_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookshelfBook)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookshelfBook_Book");

                entity.HasOne(d => d.Bookshelf)
                    .WithMany(p => p.BookshelfBook)
                    .HasForeignKey(d => d.BookshelfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookshelfBook_Bookshelf");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.TextReview)
                    .IsRequired()
                    .HasColumnName("text_review")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewBook");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

            });
        }
    }
}

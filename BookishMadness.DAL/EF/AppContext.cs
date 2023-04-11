using BookishMadness.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Book>().HasData(
               new Book { Id = Guid.NewGuid(), Name = "Lord of the ring", Author = "J. R. R. Tolkien", Description = "Description", Status = Enums.BookStatus.Reading },
               new Book { Id = Guid.NewGuid(), Name = "Caraval", Author = "Stephanie Garber", Description = "Description", Status = Enums.BookStatus.Reading },
               new Book { Id = Guid.NewGuid(), Name = "Pretty reckless", Author = "L. J. Shenn", Description = "Description", Status = Enums.BookStatus.WantToRead }
       );
        }
    }
}
using BookishMadness.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Status)
                .HasConversion<string>();
        }
    }
}
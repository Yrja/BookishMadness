using BookishMadness.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<BookSummary> BooksSummary { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Reaction>(entity =>
            {
                entity.Property(p => p.HasLike)
                .HasColumnName("Reaction")
                .HasConversion<int>();

                entity.Property(p => p.CreatedOn)
                .HasColumnType("datetime")
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

                entity.Property(p => p.ModifiedOn)
                .HasColumnType("datetime")
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            });

            modelBuilder.Entity<BookSummary>(entity =>
            {
                entity.HasNoKey().ToView("vwBooksSummary");
            });

            modelBuilder.HasDbFunction(() => BookSummary(default, default, default))
                .HasName("fn_BookSummary");
        }

        public IQueryable<BookSummary> BookSummary(DateTime dateFrom, DateTime dateTo, Guid bookId) => FromExpression(() => BookSummary(dateFrom, dateTo, bookId));
    }
}
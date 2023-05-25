using System.Xml.Linq;
using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Extensions;
using BookishMadness.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext db;

        public BookRepository(AppDbContext db)
        {
            this.db = db;
        }

        public Book Create(Book item)
        {
            db.Books.Add(item);
            return item;
        }

        public void Delete(Guid id)
        {
            var book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate);
        }

        public Book Get(Guid id)
        {
            return db.Books.Include(it => it.Author)
                .Include(it => it.Reactions)
                .Include(it => it.Genres)
                .FirstOrDefault(it => it.Id.Equals(id));
        }

        public IQueryable<Book> GetAll()
        {
            return db.Books.Include(it => it.Author)
                .Include(it => it.Reactions)
                .Include(it => it.Genres);
        }

        public Book Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public IQueryable<BookSummary> GetBooksSummary(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, bool useProcedure)
        {
            if (dateFrom is null && dateTo is null && bookId is null)
            {
                return db.BooksSummary;
            }
            else
            {
                if (useProcedure)
                    return db.LoadStoredProcedure("sp_BookSummary")
                        .WithSqlParams(
                            (nameof(dateFrom), dateFrom),
                            (nameof(dateTo), dateTo),
                            (nameof(bookId), bookId))
                        .ExecuteStoredProcedure<BookSummary>()
                        .AsQueryable();
                else
                    return db.BookSummary(dateFrom, dateTo, bookId);
            }
        }
    }
}

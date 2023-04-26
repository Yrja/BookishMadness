using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
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
                .FirstOrDefault(it => it.Id.Equals(id));
        }

        public IQueryable<Book> GetAll()
        {
            return db.Books.Include(it => it.Author);
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
    }
}

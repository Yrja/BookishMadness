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

        public void Create(Book item)
        {
            db.Books.Add(item);
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
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

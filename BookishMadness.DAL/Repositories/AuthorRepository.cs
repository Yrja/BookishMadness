using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private AppDbContext db;

        public AuthorRepository(AppDbContext db)
        {
            this.db = db;
        }

        public Author Create(Author item)
        {
            db.Authors.Add(item);
            return item;
        }

        public void Delete(Guid id)
        {
            var author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return db.Authors.Where(predicate);
        }

        public Author Get(Guid id)
        {
            return db.Authors.Find(id);
        }

        public IQueryable<Author> GetAll()
        {
            return db.Authors
                .Include(it => it.Books);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Author Update(Author item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}

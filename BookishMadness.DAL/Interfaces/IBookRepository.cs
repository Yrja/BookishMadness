using BookishMadness.DAL.Entities;

namespace BookishMadness.DAL.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Book Get(Guid id);
        IEnumerable<Book> Find(Func<Book, Boolean> predicate);
        Book Create(Book item);
        Book Update(Book item);
        IQueryable<BookSummary> GetBooksSummary();
        void Delete(Guid id);
        void SaveChanges();
    }
}

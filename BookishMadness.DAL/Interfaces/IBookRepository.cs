using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Strategy;

namespace BookishMadness.DAL.Interfaces
{
    public interface IBookRepository
    {
        public IBooksSummaryStrategy Strategy { get; set; }

        IQueryable<Book> GetAll();
        Book Get(Guid id);
        IEnumerable<Book> Find(Func<Book, Boolean> predicate);
        Book Create(Book item);
        Book Update(Book item);
        IQueryable<BookSummary> GetBooksSummary(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, bool useProcedure);
        IQueryable<BookSummary> AllBooks();
        void Delete(Guid id);
        void SaveChanges();
    }
}

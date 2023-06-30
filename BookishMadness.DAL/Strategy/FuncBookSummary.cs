using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;

namespace BookishMadness.DAL.Strategy
{
    public class FuncBookSummary : IBooksSummaryStrategy
    {
        public IQueryable<BookSummary> GetBooksSummary(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, AppDbContext db)
        {
            return db.BookSummary(dateFrom, dateTo, bookId);
        }
    }
}

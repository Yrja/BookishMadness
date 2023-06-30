using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;

namespace BookishMadness.DAL.Strategy
{
    public interface IBooksSummaryStrategy
    {
        IQueryable<BookSummary> GetBooksSummary(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, AppDbContext db);
    }
}

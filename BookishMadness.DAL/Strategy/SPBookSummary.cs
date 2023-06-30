using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Extensions;

namespace BookishMadness.DAL.Strategy
{
    public class SPBookSummary : IBooksSummaryStrategy
    {
        public IQueryable<BookSummary> GetBooksSummary(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, AppDbContext db)
        {
            return db.LoadStoredProcedure("sp_BookSummary")
            .WithSqlParams(
                (nameof(dateFrom), dateFrom),
                (nameof(dateTo), dateTo),
                (nameof(bookId), bookId))
            .ExecuteStoredProcedure<BookSummary>()
            .AsQueryable();
        }
    }
}

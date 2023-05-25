using BookishMadness.BLL.DTOs;
using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL.Interfaces
{
    public interface IBooksService
    {
        List<BookDTO> GetAllBooks();
        BookDTO Get(Guid id);
        List<BookDTO> Find();
        BookDTO Create(BookDTO item);
        BookDTO Update(BookDTO item);
        void Delete(Guid id);
        List<BookSummaryDTO> GetBookSummaries(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, bool useProcedure);
    }
}

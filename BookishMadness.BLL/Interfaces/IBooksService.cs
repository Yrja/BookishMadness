using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL.Interfaces
{
    public interface IBooksService
    {
        List<BookDTO> GetAllBooks();
        BookDTO Get(Guid id);
        List<BookDTO> Find();
        void Create(BookDTO item);
        void Update(BookDTO item);
        void Delete(Guid id);
    }
}

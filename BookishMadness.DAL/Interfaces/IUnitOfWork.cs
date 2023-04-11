using BookishMadness.DAL.Entities;

namespace BookishMadness.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        void Commit();
        void Dispose();
    }
}

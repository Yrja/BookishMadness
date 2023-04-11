using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IRepository<Book> _bookRepository;

        public EFUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_appDbContext);

                return _bookRepository;
            }
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

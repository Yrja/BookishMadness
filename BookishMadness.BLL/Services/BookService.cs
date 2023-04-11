using AutoMapper;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.BLL.Services
{
    public class BookService : IBooksService
    {
        IUnitOfWork Database { get; set; }
        private IMapper _mapper;

        public BookService(IUnitOfWork database, IMapper mapper)
        {
            Database = database;
            _mapper = mapper;
        }

        public void Create(BookDTO item)
        {
            Database.Books.Create(_mapper.Map<Book>(item));
            //Database.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Database.Books.Delete(id);
            //Database.SaveChanges();

        }

        public List<BookDTO> Find()
        {
            return _mapper.Map<List<BookDTO>>(Database.Books.Find(x => x.Author.Contains("Garber")));

        }

        public BookDTO Get(Guid id)
        {
            var book = _mapper.Map<BookDTO>(Database.Books.Get(id));
            return book;
        }

        public List<BookDTO> GetAllBooks()
        {
            var books = _mapper.Map<List<BookDTO>>(Database.Books.GetAll());
            return books;
        }

        public void Update(BookDTO item)
        {
            var book = _mapper.Map<Book>(item);
            Database.Books.Update(book);
            //Database.SaveChanges();
        }

    }
}

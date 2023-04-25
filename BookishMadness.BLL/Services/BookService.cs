using AutoMapper;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.BLL.Services
{
    public class BookService : IBooksService
    {
        IRepository<Book> Database { get; set; }
        private IMapper _mapper;

        public BookService(IRepository<Book> database, IMapper mapper)
        {
            Database = database;
            _mapper = mapper;
        }

        public BookDTO Create(BookDTO item)
        {
            var result = Database.Create(_mapper.Map<Book>(item));
            Database.SaveChanges();
            return _mapper.Map<BookDTO>(result);
        }

        public void Delete(Guid id)
        {
            Database.Delete(id);
            Database.SaveChanges();
        }

        public List<BookDTO> Find()
        {
            return _mapper.Map<List<BookDTO>>(Database.Find(x => x.Name.Contains("Pretty")));
        }

        public BookDTO Get(Guid id)
        {
            return _mapper.Map<BookDTO>(Database.Get(id));
        }

        public List<BookDTO> GetAllBooks()
        {
            return _mapper.Map<List<BookDTO>>(Database.GetAll().ToList());
        }

        public BookDTO Update(BookDTO item)
        {
            var result = Database.Update(_mapper.Map<Book>(item));
            Database.SaveChanges();
            return _mapper.Map<BookDTO>(result);
        }
    }
}

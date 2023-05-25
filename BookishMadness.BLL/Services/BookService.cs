using AutoMapper;
using BookishMadness.BLL.DTOs;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.BLL.Services
{
    public class BookService : IBooksService
    {
        private readonly IBookRepository _booksRepository;
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public BookService(IBookRepository booksDepository, IMapper mapper, IGenreRepository genreRepository)
        {
            _booksRepository = booksDepository;
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public BookDTO Create(BookDTO source)
        {
            Book sourceEntity = _mapper.Map<Book>(source);
            IEnumerable<string> sourceEntityGenres = sourceEntity.Genres.Select(it => it.Name);
            IEnumerable<Genre> currentBookDbGenres = _genreRepository.GetAllGenres()
                .ToList()
                .Where(it => sourceEntityGenres.Contains(it.Name, StringComparer.OrdinalIgnoreCase));

            foreach (var genre in currentBookDbGenres)
            {
                int genreIndex = sourceEntity.Genres.FindIndex(it => it.Name.Equals(genre.Name, StringComparison.InvariantCultureIgnoreCase));
                sourceEntity.Genres[genreIndex] = genre;
            }

            var result = _booksRepository.Create(sourceEntity);
            _booksRepository.SaveChanges();

            return _mapper.Map<BookDTO>(result);
        }

        public void Delete(Guid id)
        {
            _booksRepository.Delete(id);
            _booksRepository.SaveChanges();
        }

        public List<BookDTO> Find()
        {
            return _mapper.Map<List<BookDTO>>(_booksRepository.Find(x => x.Name.Contains("Pretty")));
        }

        public BookDTO Get(Guid id)
        {
            return _mapper.Map<BookDTO>(_booksRepository.Get(id));
        }

        public List<BookDTO> GetAllBooks()
        {
            return _mapper.Map<List<BookDTO>>(_booksRepository.GetAll().ToList());
        }

        public List<BookSummaryDTO> GetBookSummaries(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, bool useProcedure)
        {
            return _mapper.Map<List<BookSummaryDTO>>(_booksRepository.GetBooksSummary(dateFrom, dateTo, bookId, useProcedure));
        }

        public BookDTO Update(BookDTO item)
        {
            var result = _booksRepository.Update(_mapper.Map<Book>(item));
            _booksRepository.SaveChanges();
            return _mapper.Map<BookDTO>(result);
        }
    }
}

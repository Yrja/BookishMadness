using AutoMapper;
using BookishMadness.BLL.DTOs;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        IRepository<Author> Database { get; set; }
        private IMapper _mapper;

        public AuthorService(IRepository<Author> database, IMapper mapper)
        {
            Database = database;
            _mapper = mapper;
        }
        public AuthorDTO Create(AuthorDTO item)
        {
            var result = Database.Create(_mapper.Map<Author>(item));
            Database.SaveChanges();
            return _mapper.Map<AuthorDTO>(result);
        }

        public List<AuthorDTO> GetAuthors()
        {
            return _mapper.Map<List<AuthorDTO>>(Database.GetAll());
        }

        public List<AuthorDTO> Find()
        {
            return _mapper.Map<List<AuthorDTO>>(Database.Find(x => x.Name.Contains("Garber")));
        }

        public AuthorDTO Update(AuthorDTO item)
        {
            var result = Database.Update(_mapper.Map<Author>(item));
            Database.SaveChanges();
            return _mapper.Map<AuthorDTO>(result);
        }

        public void Delete(Guid id)
        {
            Database.Delete(id);
            Database.SaveChanges();
        }

        public AuthorDTO Get(Guid id)
        {
            return _mapper.Map<AuthorDTO>(Database.Get(id));
        }
    }
}

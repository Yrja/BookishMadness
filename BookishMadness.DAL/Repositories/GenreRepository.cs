using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Genre> GetAllGenres()
        {
            return _context.Genres;
        }
}
}

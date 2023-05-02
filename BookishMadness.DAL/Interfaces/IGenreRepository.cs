using BookishMadness.DAL.Entities;

namespace BookishMadness.DAL.Interfaces
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetAllGenres();
    }
}

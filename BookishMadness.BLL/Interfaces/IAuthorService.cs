using BookishMadness.BLL.DTOs;

namespace BookishMadness.BLL.Interfaces
{
    public interface IAuthorService
    {
        AuthorDTO Create(AuthorDTO item);
        List<AuthorDTO> GetAuthors();
        List<AuthorDTO> Find();
        AuthorDTO Update(AuthorDTO item);
        void Delete(Guid id);
        AuthorDTO Get(Guid id);

    }
}

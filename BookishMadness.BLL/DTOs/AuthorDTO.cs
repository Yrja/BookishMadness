using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL.DTOs
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}

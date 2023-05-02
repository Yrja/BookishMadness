using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL.DTOs
{
    public class GenreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}

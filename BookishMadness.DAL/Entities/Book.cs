using BookishMadness.DAL.Enums;

namespace BookishMadness.DAL.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public BookStatus Status { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}

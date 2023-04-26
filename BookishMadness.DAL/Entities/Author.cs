namespace BookishMadness.DAL.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}

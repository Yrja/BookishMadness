namespace BookishMadness.DAL.Entities
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public bool HasLike { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; } = null;
    }
}

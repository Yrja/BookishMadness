using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL.DTOs
{
    public class ReactionDTO
    {
        public Guid Id { get; set; }
        public bool HasLike { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

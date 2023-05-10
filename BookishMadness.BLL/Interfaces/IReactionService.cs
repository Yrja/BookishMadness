using BookishMadness.BLL.DTOs;

namespace BookishMadness.BLL.Interfaces
{
    public interface IReactionService
    {
        ReactionDTO AddReaction(ReactionDTO reaction);
        ReactionDTO UpdateReaction(ReactionDTO reaction);
        void DeleteReaction(Guid id);
    }
}

using BookishMadness.DAL.Entities;

namespace BookishMadness.DAL.Interfaces
{
    public interface IReactionRepository
    {
        Reaction AddReaction(Reaction reaction);
        Reaction UpdateReaction(Reaction reaction);
        void DeleteReaction(Guid id);
        void SaveChanges();
    }
}

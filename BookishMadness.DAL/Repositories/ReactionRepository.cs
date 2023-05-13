using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.Repositories
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly AppDbContext _context;

        public ReactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public Reaction AddReaction(Reaction reaction)
        {
            _context.Reactions.Add(reaction);
            return reaction;
        }

        public void DeleteReaction(Guid id)
        {
            var react = _context.Reactions.FirstOrDefault(it => it.Id == id);

            Reaction reaction = _context.Reactions.Find(id);
            if (reaction != null)
               _context.Reactions.Remove(reaction);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Reaction UpdateReaction(Reaction reaction)
        {
            _context.Entry(reaction).State = EntityState.Modified;
            return reaction;
        }
    }
}

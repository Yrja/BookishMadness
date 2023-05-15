using AutoMapper;
using BookishMadness.BLL.DTOs;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;

namespace BookishMadness.BLL.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionRepository _reactionRepository;
        private IMapper _mapper;

        public ReactionService(IReactionRepository reactionRepository, IMapper mapper)
        {
            _reactionRepository = reactionRepository;
            _mapper = mapper;
        }

        public ReactionDTO AddReaction(ReactionDTO reaction)
        {
            var result = _reactionRepository.AddReaction(_mapper.Map<Reaction>(reaction));
            _reactionRepository.SaveChanges();
            return _mapper.Map<ReactionDTO>(result);
        }

        public void DeleteReaction(Guid id)
        {
            _reactionRepository.DeleteReaction(id);
            _reactionRepository.SaveChanges();
        }

        public ReactionDTO UpdateReaction(ReactionDTO reaction)
        {   
            var result = _reactionRepository.UpdateReaction(_mapper.Map<Reaction>(reaction));
            _reactionRepository.SaveChanges();
            return _mapper.Map<ReactionDTO>(result);
        }
    }
}

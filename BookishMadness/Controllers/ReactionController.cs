using BookishMadness.BLL.DTOs;
using BookishMadness.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookishMadness.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReactionController : Controller
    {
        private IReactionService _reactionService;

        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }

        [HttpPost]
        public ReactionDTO AddReaction(ReactionDTO reaction)
        {
            return _reactionService.AddReaction(reaction);
        }

        [HttpPut]
        public ReactionDTO EditReaction(ReactionDTO reaction)
        {
            return _reactionService.UpdateReaction(reaction);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteReaction(Guid id)
        {
            _reactionService.DeleteReaction(id);
            return Ok();
        }
    }
}

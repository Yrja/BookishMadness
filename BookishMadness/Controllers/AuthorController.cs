using BookishMadness.BLL.DTOs;
using BookishMadness.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookishMadness.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<AuthorDTO>> AllAuthors()
        {
            return _service.GetAuthors();
        }

        [HttpGet]
        public ActionResult<AuthorDTO> Details(Guid id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        public ActionResult<AuthorDTO> Create(AuthorDTO author)
        {
           return _service.Create(author);
        }

        [HttpPut]
        public ActionResult<AuthorDTO> Edit(AuthorDTO author)
        {
            return _service.Update(author);
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}

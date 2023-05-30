using BookishMadness.BLL.DTOs;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookishMadness.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public ActionResult<List<BookDTO>> AllBooks()
        {
            return _booksService.GetAllBooks();
        }

        [HttpGet]
        public ActionResult<BookDTO> Details(Guid id)
        {
            return _booksService.Get(id);
        }

        [HttpPost]
        public ActionResult<BookDTO> Create(BookDTO book)
        {
            return _booksService.Create(book);
        }

        [HttpPut]
        public ActionResult<BookDTO> Edit(BookDTO book)
        {
            return _booksService.Update(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            _booksService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<BookSummaryDTO>> AllBooksSummaries(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, bool useProcedure = true)
        {
            return _booksService.GetBookSummaries(dateFrom, dateTo, bookId, useProcedure);
        }
    }
}

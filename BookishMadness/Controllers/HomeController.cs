using System.Diagnostics;
using BookishMadness.BLL.Interfaces;
using BookishMadness.DAL.Entities;
using BookishMadness.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookishMadness.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBooksService _booksService;

        public HomeController(ILogger<HomeController> logger, IBooksService booksService)
        {
            _logger = logger;
            _booksService = booksService;
        }

        public ActionResult<List<BookDTO>> Index()
        {
            var it = _booksService.GetAllBooks();
            return it;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
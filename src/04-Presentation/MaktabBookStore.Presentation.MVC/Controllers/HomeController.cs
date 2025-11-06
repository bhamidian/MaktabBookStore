using System.Diagnostics;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Presentation.MVC.Models;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Books = _bookService.GetBooks(5),
                Categories = _bookService.GetCategories(),
            };

            return View(model);
        }


    }
}

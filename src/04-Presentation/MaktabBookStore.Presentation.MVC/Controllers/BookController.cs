using MaktabBookStore.Domain.AuthorAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;

        public BookController(
            IBookService bookService,
            ICategoryService categoryService,
            IAuthorService authorService
        )
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Index(GetBooksViewModel model)
        {
            var books = _bookService.GetBooks();

            model.GetBooks = books;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new AddBookViewModel
            {
                GetAuthors = _authorService.GetAll(),
                GetCategories = _categoryService.GetAll(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AddBookViewModel model, IFormFile ImagePath)
        {
            if (ImagePath != null && ImagePath.Length > 0)
            {
                var uploadsFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "Books"
                );
                var fileName = Path.GetFileName(ImagePath.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImagePath.CopyTo(stream);
                }

                model.ImagePath = "images\\Books\\" + fileName;
            }

            var Categories = _categoryService.GetAll();
            var authors = _authorService.GetAll();

            var newbook = new AddBookDTO()
            {
                BookTitle = model.BookTitle,
                Count = model.Count,
                Pages = model.Pages,
                ImagePath = model.ImagePath,
                PublishedDate = model.PublishedDate,
                Price = model.Price,
                CategoryId = model.CategoryId,
                AuthorId = model.AuthorId,
            };

            var book = _bookService.AddBook(newbook);

            return RedirectToAction("Index", "Book");
        }
    }
}

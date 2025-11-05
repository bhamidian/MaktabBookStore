using MaktabBookStore.Domain.AuthorAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IUserService _userService;

        public AdminController(
            IBookService bookService,
            ICategoryService categoryService,
            IAuthorService authorService,
            IUserService userService
        )
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _userService = userService;
        }

        // [HttpGet]
        // public IActionResult Index()
        // {
        //     //var user = InMemoryDatabase.OnlineUser;

        //     //if (user is not null && user.Role is Role.Admin)
        //     //{

        //     //}
        //     //else
        //     //{
        //     //    return RedirectToAction("UnAuthorize");

        //     //}
        //     return View(new AdminPanelViewModel());
        // }

        [HttpGet]
        public IActionResult Index(AdminPanelViewModel model)
        {
            var bookcount = _bookService.GetBooks().Count;
            var usercount = _userService.GetUsers().Count;
            var categorycount = _categoryService.GetAll().Count;

            model.BookCount = bookcount;
            model.UserCount = usercount;
            model.CategoryCount = categorycount;

            return View(model);
        }

        [HttpGet]
        public IActionResult UnAuthorize()
        {
            return View();
        }

        public IActionResult AddBook()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Authors = _authorService.GetAll();

            return View(new AddBookViewModel());
        }

        [HttpPost]
        public IActionResult AddBook(AddBookViewModel model, IFormFile ImagePath)
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

            ViewBag.BookAdded = book.Message;
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Authors = _authorService.GetAll();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetUsers(GetUserViewModel model)
        {
            model.Users = _userService.GetUsers();

            return View(model);
        }

        [HttpGet]
        public IActionResult EditRoleUser()
        {
            return View(new EditUserViewModel());
        }

        // [HttpGet]
        // public IActionResult EditRoleUser(int id)
        // {

        //     var model = new EditUserViewModel { Id = user.Id, Role = user.Role };

        //     return View(model);
        // }

        [HttpPost]
        public IActionResult EditUserRole(EditUserViewModel model)
        {
            var edit = _userService.EditRole(model.Id, model.Role);

            if (edit.IsSuccess)
            {
                ViewBag.Success = edit.Message;
                return View();
            }

            ViewBag.Error = edit.Message;
            return View();
        }

        [HttpGet]
        public IActionResult DeleteUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var remove = _userService.DeleteUser(id);

            if (remove.IsSuccess)
            {
                ViewBag.Result = remove.Message;
                return View("GetUsers");
            }

            ViewBag.Result = remove.Message;
            return View("GetUsers");
        }

        public IActionResult GetBooks(GetBooksViewModel model)
        {
            model.GetBooks = _bookService.GetBooks();

            return View(model);
        }
    }
}

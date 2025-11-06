using MaktabBookStore.Domain.AuthorAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.DTOs;
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
    }
}

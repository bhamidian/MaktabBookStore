using MaktabBookStore.Domain.AuthorAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public AdminController(
            IBookService bookService,
            ICategoryService categoryService,
            IUserService userService
        )
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(AdminPanelViewModel model)
        {
            var bookcount = _bookService.GetAll().Count;
            var usercount = _userService.GetAll().Count;
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

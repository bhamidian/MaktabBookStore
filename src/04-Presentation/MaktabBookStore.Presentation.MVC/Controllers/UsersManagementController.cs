using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class UsersManagementController : Controller
    {
        private readonly IUserService _userService;

        public UsersManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(GetUserViewModel model)
        {
            model.Users = _userService.GetUsers();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new CreateUserViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            var dto = new RegisterDTO
            {
                MobileNumber = model.MobileNumber,
                Password = model.Password,
                Role = model.Role,
            };

            _userService.Register(dto);

            return View(model);
        }

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
    }
}

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
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            var model = new GetUsersViewModel { Users = users };

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

        [HttpGet]
        public IActionResult Update(int id, GetUserViewModel model)
        {
            var user = _userService.GetById(id);

            if (user.Data is null)
            {
                ViewBag.Error = user.Message;
                return View();
            }

            model.Id = user.Data.Id;
            model.MobileNumber = user.Data.MobileNumber;
            model.Role = user.Data.Role;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(GetUserViewModel model)
        {
            var user = new GetUserDTO
            {
                Id = model.Id,
                MobileNumber = model.MobileNumber,
                Role = model.Role,
            };

            var result = _userService.Update(user);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

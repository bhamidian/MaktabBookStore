using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Enums;
using MaktabBookStore.Infrastructure.EFCore.InMemory;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) => _userService = userService;

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loginresult = _userService.Login(model.MobileNumber, model.Password);

            if (loginresult.IsSuccess)
            {
                if (loginresult.Data!.Role == Role.Admin)
                {
                    InMemoryDatabase.OnlineUser = new OnlineUser
                    {
                        Id = loginresult.Data.Id,
                        MobileNumber = loginresult.Data.MobileNumber,
                        Role = loginresult.Data.Role,
                    };
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.LoginError = loginresult.Message;
                }
            }
            else
            {
                ViewBag.LoginError = loginresult.Message;
            }

            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var dto = new RegisterDTO
            {
                MobileNumber = model.MobileNumber,
                Password = model.Password,
                Role = model.Role,
            };

            var register = _userService.Register(dto);

            if (register.IsSuccess)
            {
                ViewBag.RegisterMessage = register.Message;
                return View(model);
            }
            else
            {
                ViewBag.RegisterMessage = register.Message;
                return View();
            }
        }
    }
}

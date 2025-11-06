using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Presentation.MVC.Models.ViewModels;
using MaktabBookStore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MaktabBookStore.Presentation.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(GetCategoriesViewModel model)
        {
            var categories = _categoryService.GetAll();
            model.GetCategories = categories;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}

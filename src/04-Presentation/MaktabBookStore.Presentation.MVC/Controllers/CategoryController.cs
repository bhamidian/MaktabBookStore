using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Domain.CategoryAgg.DTOs;
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

        [HttpPost]
        public IActionResult Create(GetCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string relativePath = null;

            if (model.Image != null && model.Image.Length > 0)
            {
                var uploadDir = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "Logos"
                );

                var originalFileName = Path.GetFileName(model.Image.FileName ?? string.Empty);
                var extension = Path.GetExtension(originalFileName);
                var safeFileName = $"{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine(uploadDir, safeFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                relativePath = Path.Combine("images", "Logos", safeFileName).Replace("\\", "/");
            }

            var dto = new GetCategoriesDTO { CategoryName = model.Name, LogoPath = relativePath };

            var result = _categoryService.Create(dto);

            if (result.IsSuccess)
                return RedirectToAction("Index");

            ViewBag.Message = result.Message;
            ViewBag.IsSuccess = false;
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _categoryService.Get(id);

            if (!result.IsSuccess || result.Data == null)
            {
                return RedirectToAction("Index");
            }

            var model = new GetCategoryViewModel
            {
                Id = result.Data.Id,
                Name = result.Data.CategoryName,
                LogoPath = result.Data.LogoPath,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(GetCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string relativePath = model.LogoPath;

            if (model.Image != null && model.Image.Length > 0)
            {
                var uploadDir = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "Logos"
                );

                var originalFileName = Path.GetFileName(model.Image.FileName ?? string.Empty);
                var extension = Path.GetExtension(originalFileName);
                var safeFileName = $"{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine(uploadDir, safeFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                relativePath = Path.Combine("images", "Logos", safeFileName).Replace("\\", "/");
            }

            var dto = new GetCategoriesDTO
            {
                Id = model.Id ?? 0,
                CategoryName = model.Name,
                LogoPath = relativePath,
            };

            var result = _categoryService.Update(dto);

            if (result.IsSuccess)
                return RedirectToAction("Index");

            ViewBag.Message = result.Message;
            ViewBag.IsSuccess = false;
            return View(model);
        }
    }
}

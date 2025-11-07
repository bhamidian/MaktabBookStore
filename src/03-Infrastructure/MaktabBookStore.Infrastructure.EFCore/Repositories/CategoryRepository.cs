using MaktabBookStore.Domain.CategoryAgg.Contracts.Repositories;
using MaktabBookStore.Domain.CategoryAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.Entities;
using MaktabBookStore.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public bool Create(GetCategoriesDTO dTO)
        {
            var category = new Category
            {
                Id = dTO.Id,
                Name = dTO.CategoryName,
                LogoPath = dTO.LogoPath,
            };
            _dbContext.Categories.Add(category);

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

            if (category is null)
                return false;

            _dbContext.Categories.Remove(category);

            return _dbContext.SaveChanges() > 0;
        }

        public GetCategoriesDTO? GetById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
                return null;

            var newcategory = new GetCategoriesDTO
            {
                Id = category.Id,
                CategoryName = category.Name,
                LogoPath = category.LogoPath,
            };
            return newcategory;
        }

        public List<GetCategoriesDTO> GetAll()
        {
            var categories = _dbContext
                .Categories.ToList()
                .Select(c =>
                {
                    var fileName = Path.GetFileName(c.LogoPath ?? string.Empty);
                    var webPath = string.IsNullOrEmpty(fileName)
                        ? "/images/Logos/default.jpg"
                        : $"/images/Logos/{fileName}";

                    return new GetCategoriesDTO
                    {
                        Id = c.Id,
                        CategoryName = c.Name,
                        LogoPath = c.LogoPath,
                    };
                })
                .ToList();

            return categories;
        }

        public bool Update(GetCategoriesDTO dTO)
        {
            var update = _dbContext
                .Categories.Where(c => c.Id == dTO.Id)
                .ExecuteUpdate(setters =>
                    setters
                        .SetProperty(c => c.Name, dTO.CategoryName)
                        .SetProperty(c => c.LogoPath, dTO.LogoPath)
                );

            return update > 0;
        }
    }
}

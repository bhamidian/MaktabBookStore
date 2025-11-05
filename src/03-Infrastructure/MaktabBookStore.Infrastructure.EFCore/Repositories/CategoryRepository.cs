using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Repositories;
using MaktabBookStore.Domain.CategoryAgg.DTOs;
using MaktabBookStore.Infrastructure.EFCore.Persistence;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public List<GetCategoriesDTO> GetAll()
        {
            var categories = _dbContext
                .Categories.Select(c => new GetCategoriesDTO
                {
                    Id = c.Id,
                    CategoryName = c.Name,
                    Logo = c.Logo,
                })
                .ToList();

            return categories;
        }
    }
}

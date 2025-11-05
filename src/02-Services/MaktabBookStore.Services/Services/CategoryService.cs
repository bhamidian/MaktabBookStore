using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Repositories;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public List<GetCategoriesDTO> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}

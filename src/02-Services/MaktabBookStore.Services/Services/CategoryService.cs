using MaktabBookStore.Domain._common.DTOs;
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

        public ResultDTO<bool> Create(GetCategoriesDTO dTO)
        {
            var result = _categoryRepository.Create(dTO);

            if (result)
                return ResultDTO<bool>.Success("دسته بندی با موفقیت اضافه شد");

            return ResultDTO<bool>.Fail("مشکلی در هنگام ثبت کاربر به وجود امد");
        }

        public ResultDTO<bool> Delete(int id)
        {
            var result = _categoryRepository.Delete(id);

            if (result)
                return ResultDTO<bool>.Success("دسته بندی با موفقیت حذف شد");

            return ResultDTO<bool>.Fail("مشکلی هنگام حذف به وجود امد");
        }

        public ResultDTO<GetCategoriesDTO?> Get(int id)
        {
            var result = _categoryRepository.GetById(id);

            if (result is null)
                return ResultDTO<GetCategoriesDTO?>.Fail("دسته بندی پیدا نشد");

            return ResultDTO<GetCategoriesDTO?>.Success(data: result);
        }

        public List<GetCategoriesDTO> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public ResultDTO<bool> Update(GetCategoriesDTO dTO)
        {
            var result = _categoryRepository.Update(dTO);

            if (result)
                return ResultDTO<bool>.Success("دسته بندی با موفقیت اپدیت شد");

            return ResultDTO<bool>.Fail("مشکلی هنگام اپدیت به وجود امد");
        }
    }
}

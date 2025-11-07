using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Domain.CategoryAgg.Contracts.Services
{
    public interface ICategoryService
    {
        List<GetCategoriesDTO> GetAll();
        ResultDTO<bool> Add(GetCategoriesDTO dTO);
        ResultDTO<bool> Update(GetCategoriesDTO dTO);
        ResultDTO<bool> Delete(int id);
        ResultDTO<GetCategoriesDTO?> Get(int id);
    }
}

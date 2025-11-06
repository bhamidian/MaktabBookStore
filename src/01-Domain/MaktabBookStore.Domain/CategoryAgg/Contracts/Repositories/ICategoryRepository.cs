using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Domain.CategoryAgg.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoriesDTO> GetAll();
        bool Add(GetCategoriesDTO dTO);
        bool Update(GetCategoriesDTO dTO);
        bool Delete(int id);
    }
}

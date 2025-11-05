using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Domain.CategoryAgg.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoriesDTO> GetAll();
        // bool Add();
    }
}

using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Domain.BookAgg.Contracts.Repositories
{
    public interface IBookRepository
    {
        List<GetBookDTO> GetAll(int count);
        List<GetBookDTO> GetAll();
        List<GetCategoriesDTO> GetCategories();
        bool Create(AddBookDTO dTO);
        bool Delete(int id);
    }
}

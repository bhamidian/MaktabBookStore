using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Domain.BookAgg.Contracts.Repositories
{
    public interface IBookRepository
    {
        List<GetBookDTO> GetBooks(int count);
        List<GetBookDTO> GetBooks();
        List<GetCategoriesDTO> GetCategories();
        bool AddBook(AddBookDTO dTO);
        bool DeleteBook(int id);
    }
}

using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.BookAgg.Contracts.Repositories;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo) => _bookRepo = bookRepo;

        public ResultDTO<bool> Create(AddBookDTO dTO)
        {
            var result = _bookRepo.Create(dTO);

            if (result)
            {
                return ResultDTO<bool>.Success("کتاب با موفقیت اضافه شد");
            }
            else
            {
                return ResultDTO<bool>.Fail("کتاب اضافه نشد");
            }
        }

        public List<GetBookDTO> GetAll(int count)
        {
            var books = _bookRepo.GetAll(count);

            return books
                .Select(s => new GetBookDTO
                {
                    AuthorName = s.AuthorName,
                    Pages = s.Pages,
                    ImagePath = s.ImagePath,
                    Price = s.Price,
                    Title = s.Title,
                })
                .ToList();
        }

        public List<GetBookDTO> GetAll()
        {
            var books = _bookRepo.GetAll();

            return books;
        }

        public List<GetCategoriesDTO> GetCategories()
        {
            return _bookRepo.GetCategories();
        }
    }
}

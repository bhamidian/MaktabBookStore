using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ResultDTO<bool> AddBook(AddBookDTO dTO)
        {
            var result = _bookRepo.AddBook(dTO);

            if (result)
            {
                return ResultDTO<bool>.Success("کتاب با موفقیت اضافه شد");
            }
            else
            {
                return ResultDTO<bool>.Fail("کتاب اضافه نشد");
            }
        }

        public List<GetBookDTO> GetBooks(int count)
        {
            var books = _bookRepo.GetBooks(count);

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

        public List<GetBookDTO> GetBooks()
        {
            var books = _bookRepo.GetBooks();

            // return books
            //     .Select(s => new GetBookDTO
            //     {
            //         AuthorName = s.AuthorName,
            //         Pages = s.Pages,
            //         ImagePath = s.ImagePath,
            //         Price = s.Price,
            //         Title = s.Title,
            //     })
            //     .ToList();
            return books;
        }

        public List<GetCategoriesDTO> GetCategories()
        {
            return _bookRepo.GetCategories();
        }
    }
}

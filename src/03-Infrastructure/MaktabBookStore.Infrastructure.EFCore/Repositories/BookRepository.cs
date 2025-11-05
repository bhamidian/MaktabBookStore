using MaktabBookStore.Domain.BookAgg.Contracts.Repositories;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.BookAgg.Entities;
using MaktabBookStore.Domain.CategoryAgg.DTOs;
using MaktabBookStore.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddBook(AddBookDTO dTO)
        {
            var book = new Book
            {
                ImagePath = dTO.ImagePath,
                Pages = dTO.Pages,
                Price = dTO.Price,
                BookTitle = dTO.BookTitle,
                PublishedDate = dTO.PublishedDate,
                Count = dTO.Count,
                CategoryId = dTO.CategoryId,
                AuthorId = dTO.AuthorId,
            };

            _dbContext.Books.Add(book);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteBook(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return false;
            }
            _dbContext.Books.Remove(book);

            return _dbContext.SaveChanges() > 0;
        }

        public List<GetBookDTO> GetBooks()
        {
            try
            {
                var books = _dbContext
                    .Books.Include(b => b.Author)
                    .OrderByDescending(b => b.PublishedDate)
                    .ToList()
                    .Select(g =>
                    {
                        var fileName = Path.GetFileName(g.ImagePath ?? string.Empty);
                        var webPath = string.IsNullOrEmpty(fileName)
                            ? "/images/Books/default.jpg"
                            : $"/images/Books/{fileName}";

                        return new GetBookDTO
                        {
                            PublishedDate = g.PublishedDate,
                            AuthorName = g.Author?.FullName ?? "",
                            Title = g.BookTitle,
                            Price = g.Price,
                            Pages = g.Pages,
                            ImagePath = webPath,
                            CategoryId = g.CategoryId,
                            AuthorId = g.AuthorId,
                        };
                    })
                    .ToList();

                return books;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GetBookDTO> GetBooks(int count)
        {
            try
            {
                var books = _dbContext
                    .Books.Include(b => b.Author)
                    .OrderByDescending(b => b.PublishedDate)
                    .Take(count)
                    .ToList()
                    .Select(g =>
                    {
                        var fileName = Path.GetFileName(g.ImagePath ?? string.Empty);
                        var webPath = string.IsNullOrEmpty(fileName)
                            ? "/images/Books/default.jpg"
                            : $"/images/Books/{fileName}";

                        return new GetBookDTO
                        {
                            PublishedDate = g.PublishedDate,
                            AuthorName = g.Author?.FullName ?? "",
                            Title = g.BookTitle,
                            Price = g.Price,
                            Pages = g.Pages,
                            ImagePath = webPath,
                            CategoryId = g.CategoryId,
                            AuthorId = g.AuthorId,
                        };
                    })
                    .ToList();

                return books;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GetCategoriesDTO> GetCategories()
        {
            var categories = _dbContext
                .Categories.Select(c => new GetCategoriesDTO
                {
                    CategoryName = c.Name,
                    Logo = c.Logo,
                })
                .ToList();

            return categories;
        }
    }
}

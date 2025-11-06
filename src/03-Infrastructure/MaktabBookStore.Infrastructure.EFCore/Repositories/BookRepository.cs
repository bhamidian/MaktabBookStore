using MaktabBookStore.Domain.BookAgg.Contracts.Repositories;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.BookAgg.Entities;
using MaktabBookStore.Domain.CategoryAgg.DTOs;
using MaktabBookStore.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public bool AddBook(AddBookDTO dto)
    {
        var entity = new Book
        {
            BookTitle = dto.BookTitle,
            Price = dto.Price,
            Count = dto.Count,
            Pages = dto.Pages,
            ImagePath = dto.ImagePath,
            PublishedDate = dto.PublishedDate,
            CategoryId = dto.CategoryId,
            AuthorId = dto.AuthorId,
        };

        _dbContext.Books.Add(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public bool DeleteBook(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetBookDTO> GetBooks()
    {
        var books = _dbContext
            .Books.Include(b => b.Author)
            .Include(b => b.Category)
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
                    CategoryName = g.Category?.Name ?? "",
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

    public List<GetBookDTO> GetBooks(int count) => GetBooks().Take(count).ToList();

    public List<GetCategoriesDTO> GetCategories()
    {
        return _dbContext
            .Categories.Select(c => new GetCategoriesDTO
            {
                Id = c.Id,
                LogoPath = c.LogoPath,
                CategoryName = c.Name,
            })
            .ToList();
    }
}

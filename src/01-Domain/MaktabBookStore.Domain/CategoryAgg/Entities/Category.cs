using MaktabBookStore.Domain._common.Entities;
using MaktabBookStore.Domain.BookAgg.Entities;

namespace MaktabBookStore.Domain.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        List<Book> Books { get; set; }
        public string? LogoPath { get; set; }
    }
}

using MaktabBookStore.Domain._common.Entities;
using MaktabBookStore.Domain.BookAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        List<Book> Books { get; set; }
        public string? Logo { get; set; }
    }
}
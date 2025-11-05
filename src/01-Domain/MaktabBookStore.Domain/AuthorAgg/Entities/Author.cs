using MaktabBookStore.Domain._common.Entities;
using MaktabBookStore.Domain.BookAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.AuthorAgg.Entities
{
    public class Author : BaseEntity
    {
        public string? FullName { get; set; }
        public List<Book> Books { get; set; }
    }
}
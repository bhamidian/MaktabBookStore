using MaktabBookStore.Domain._common.Entities;
using MaktabBookStore.Domain.AuthorAgg.Entities;
using MaktabBookStore.Domain.CategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.BookAgg.Entities
{
    public class Book : BaseEntity
    {
        public string BookTitle { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishedDate { get; set; }
        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
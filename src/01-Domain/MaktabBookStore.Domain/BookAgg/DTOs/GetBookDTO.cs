using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.BookAgg.DTOs
{
    public class GetBookDTO
    {
        public DateTime? PublishedDate { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public int? AuthorId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}

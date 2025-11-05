using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.BookAgg.DTOs
{
    public class AddBookDTO
    {
        public string BookTitle { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
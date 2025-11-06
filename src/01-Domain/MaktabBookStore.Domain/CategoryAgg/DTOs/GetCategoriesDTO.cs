using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.CategoryAgg.DTOs
{
    public class GetCategoriesDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string LogoPath { get; set; } = string.Empty;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class GetCategoriesViewModel
    {
        public List<GetCategoriesDTO> GetCategories { get; set; } = [];
    }
}

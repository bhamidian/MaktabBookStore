using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.BookAgg.DTOs;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class GetBooksViewModel
    {
        public List<GetBookDTO> GetBooks { get; set; } = [];
    }
}

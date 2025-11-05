using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<GetBookDTO> Books { get; set; }
        public List<GetCategoriesDTO> Categories { get; set; }
    }
}

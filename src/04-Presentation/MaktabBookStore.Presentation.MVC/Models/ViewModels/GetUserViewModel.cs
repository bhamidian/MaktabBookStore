using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class GetUserViewModel
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }
    }
}

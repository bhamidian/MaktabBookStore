using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class GetUsersViewModel
    {
        public List<GetUserDTO> Users { get; set; }
    }
}

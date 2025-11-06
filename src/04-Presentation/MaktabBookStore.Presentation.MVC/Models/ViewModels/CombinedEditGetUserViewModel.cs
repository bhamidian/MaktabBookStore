using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class CombinedEditGetUserViewModel
    {
        public EditUserViewModel Edit { get; set; }
        public GetUsersViewModel Get { get; set; }
    }
}

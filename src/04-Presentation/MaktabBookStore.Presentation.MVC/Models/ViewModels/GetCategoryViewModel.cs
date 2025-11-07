using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class GetCategoryViewModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}

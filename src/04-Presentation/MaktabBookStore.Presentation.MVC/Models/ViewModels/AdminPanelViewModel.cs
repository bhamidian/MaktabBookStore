using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class AdminPanelViewModel
    {
        public int BookCount { get; set; }
        public int UserCount { get; set; }
        public int PurchasedBooks { get; set; }
        public int CategoryCount { get; set; }
    }
}

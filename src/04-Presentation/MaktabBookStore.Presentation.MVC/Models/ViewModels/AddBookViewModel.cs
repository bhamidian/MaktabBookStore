namespace MaktabBookStore.Presentation.MVC.Models.ViewModels
{
    public class AddBookViewModel
    {
        public string BookTitle { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}

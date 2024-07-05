namespace QBO.WebApp.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}

namespace Bookish.Models.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public List<string> Authors { get; set;}
    }
}
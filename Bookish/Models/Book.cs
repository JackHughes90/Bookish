namespace Bookish.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public List<Author> Authors { get; set;}
        public List<Genre> Genres { get; set; }
    }
}
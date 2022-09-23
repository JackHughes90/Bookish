namespace Bookish.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set;}
        public List<Tag> Tags { get; set; }
    }
}
namespace Bookish.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<Book> Books { get; set; }
    }
}
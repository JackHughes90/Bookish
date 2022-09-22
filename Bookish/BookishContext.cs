namespace Bookish
{
public class BookishContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void
    optionsBuilder.UseNpgsql(npgsql connections string)
}
}
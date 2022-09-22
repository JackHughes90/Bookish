using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // List<Book> books = new List<Book>
        // {
        //     new Book
        //     {
        //         Title = "Mary Poppins",
        //         Author = "P. L. Travers"
        //     },
        //     new Book
        //     {
        //         Title = "A Brief History of Time",
        //         Author = "Stephen Hawking"
        //     },
        //     new Book
        //     {
        //         Title = "The Witcher",
        //         Author = "Andrezej Sapkowski"
        //     }
        // };

        var context = new BookishContext();
        List<Book> books = context.Books
            .Include(b => b.Authors)
            .ToList();

        return View(books);
    }
}

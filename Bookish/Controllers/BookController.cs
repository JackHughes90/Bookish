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
        var context = new BookishContext();
        List<Book> books = context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .ToList();

        return View(books);
    }

    [HttpPost("")]
    public IActionResult Create([FromForm] Book newBook)
    {
        var context = new BookishContext();
        var addedEntity = context.Books.Add(newBook);
    }

    // [HttpGet]
    // public IActionResult Add()
    // {
    //     return View();
    // }
}

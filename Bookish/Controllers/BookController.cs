using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Models.Requests;
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
    public IActionResult Create([FromForm] CreateBookRequest newBookRequest)
    {
        var context = new BookishContext();

        // Make new authors (quick and dirty - will duplicate authors of same name)
        List<Author> newBookAuthors = new List<Author>();
        foreach (string authorName in newBookRequest.Authors)
        {
            Author? existingAuthor = context.Authors.Where(a => a.Name == authorName).SingleOrDefault();
            if (existingAuthor is not null)
            {
                newBookAuthors.Add(existingAuthor);
                break;
            }

            Author newAuthor = new Author()
            {
                Name = authorName
            };
            var insertedAuthorEntity = context.Add(newAuthor);
            newBookAuthors.Add(insertedAuthorEntity.Entity);
        }

        Book newBook = new Book
        {
            Title   = newBookRequest.Title,
            Image   = newBookRequest.Image,
            Authors = newBookAuthors,
        };

        var addedEntity = context.Books.Add(newBook);

        context.SaveChanges();

        Book addedBook = addedEntity.Entity;

        return RedirectToAction("Index");
    }

    [HttpGet("create")]
    public IActionResult BookForm()
    {
        return View();
    }
}

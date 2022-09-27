using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers;

public class BookInventoryController : Controller
{
    private readonly ILogger<BookInventoryController> _logger;

    public BookInventoryController(ILogger<BookInventoryController> logger)
    {
        _logger = logger;
    }

    [HttpPost("")]
    public IActionResult addCopy([FromForm] BookInventory newBookCopy)
    {
        var context = new BookishContext(); // all the database jazz

        BookInventory bookInventory = new BookInventory();
       

        /*  - In the controller
            get all books. 
        */

        List<Book> books = context.Books
                            .ToList();


        /*    - In the form
            List all books
            Tick if are in stock
            Submit form     
        */

        Book bookCopy = new Book
        {
            Id = newBookCopy.Id,
        };

        var addedEntity = context.Books.Add(bookCopy);

        context.SaveChanges();

        Book addedBook = addedEntity.Entity;

        return RedirectToAction("Index");
    }

    [HttpGet("addCopy")]
    public IActionResult BookCopyForm()
    {
        return View();
    }
    
}

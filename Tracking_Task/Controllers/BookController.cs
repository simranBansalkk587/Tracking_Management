using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Data;
using Tracking_Task.IRepository;
using Tracking_Task.Models;

namespace Tracking_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ApplicationDbContext _context;
        public BookController(IBooksRepository booksRepository,ApplicationDbContext context)
        {
            _booksRepository = booksRepository;
            _context = context;
        }
       
        
        [HttpGet]
        public IActionResult GetBooks()
        
        
        {
            return Ok(_context.Books.Include(u => u.User).ToList());

        }


        //public IActionResult SaveBooks(Books book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _booksRepository.AddBook(book);
        //        return Ok();
        //    }
        //    return BadRequest(ModelState);
        //}
        [HttpPost]
        public IActionResult BookSave([FromBody] Books books)
        {
            var bookInDb = _context.Books.Include(b => b.User).FirstOrDefault();
            if (bookInDb != null && ModelState.IsValid)
            {
                books.UserId = bookInDb.User.Id; // Set the foreign key value

                _context.Books.Add(books);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut]
public IActionResult BookUpdate([FromBody] Books books)
{
    var bookInDb = _context.Books.Include(u => u.User).FirstOrDefault();
    if (bookInDb != null && ModelState.IsValid)
    {
        books.UserId = bookInDb.UserId; // Assign the foreign key value from the existing book

        _context.Entry(bookInDb).CurrentValues.SetValues(books); // Update the bookInDb entity with the new values
        _context.SaveChanges();
        return Ok();
    }
    return BadRequest();
}

        ////[HttpDelete("{id}")]
        ////public Task Delete(int id)
        ////{
        ////    return _booksRepository.DeleteBook(id);
        ////}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Find the book with the given id in the database
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            // Check if the book exists
            if (book == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Remove the book from the database
            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent(); // Return a 204 No Content response
        }

    }
}

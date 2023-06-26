using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ApplicationDbContext _context;
        public BookController(IBooksRepository booksRepository, ApplicationDbContext context)
        {
            _booksRepository = booksRepository;
            _context = context;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {

            var allBooks = _context.Books.Include(u => u.User).ToList();

            return Ok(allBooks);

        }


        [HttpPost]

        public IActionResult BookSave([FromBody] Books books)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == books.UserId);
            if (userInDb != null && ModelState.IsValid)
            {
                books.User = userInDb;
                _context.Books.Add(books);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }



        //[HttpPut]
        // public IActionResult BookUpdatee([FromBody] Books books)
        // {
        //     var userInDb = _context.Users.FirstOrDefault(u => u.Id == books.UserId);
        //     if (userInDb != null && ModelState.IsValid)
        //     {
        //         books.User = userInDb;
        //         _context.Books.Update(books);
        //         _context.SaveChanges();

        //         return Ok();
        //     }
        //     return BadRequest();
        // }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var getid = _context.Books.Include(x => x.User).Where(x => x.UserId == id).ToList();

            return Ok(getid);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var book = _context.Books.FirstOrDefault(b => b.Id == id);


            if (book == null)
            {
                return NotFound();
            }


            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpPut]
        public IActionResult BookUpdate([FromBody] Books books)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == books.UserId);
            if (userInDb != null && ModelState.IsValid)
            {
                books.User = userInDb;

                
                var existingBook = _context.Books.FirstOrDefault(b => b.Id == books.Id);

                if (existingBook != null)
                {
                   
                    var changes = new List<string>();

                    if (existingBook.Title != books.Title)
                    {
                        changes.Add($"Title: '{existingBook.Title}' -> '{books.Title}'");
                        existingBook.Title = books.Title;
                    }

                    if (existingBook.Author != books.Author)
                    {
                        changes.Add($"Author: '{existingBook.Author}' -> '{books.Author}'");
                        existingBook.Author = books.Author;
                    }
                    if (existingBook.PublishedDate != books.PublishedDate)
                    {
                        changes.Add($"PublishedDate: '{existingBook.PublishedDate}' -> '{books.PublishedDate}'");
                        existingBook.PublishedDate = books.PublishedDate;
                    }
                    if (existingBook.ISBN != books.ISBN)
                    {
                        changes.Add($"ISBN: '{existingBook.ISBN}' -> '{books.ISBN}'");
                        existingBook.ISBN = books.ISBN;
                    }
                    if (existingBook.UserId != books.UserId)
                    {
                        changes.Add($"UserId: '{existingBook.UserId}' -> '{books.UserId}'");
                        existingBook.UserId = books.UserId;
                    }
                    if (existingBook.User != books.User)
                    {
                        changes.Add($"User: '{existingBook.User}' -> '{books.User}'");
                        existingBook.User = books.User;
                    }
                   

                    if (changes.Any())
                    {
                        _context.Books.Update(existingBook);

                        var trackDetails = new TrackData
                        {
                            BooksId = books.Id,
                            Books = existingBook,
                            Change = string.Join(", ", changes),
                            Trackingdate = DateTime.Now
                        };

                       
                        _context.TrackData.Add(trackDetails);
                    }

                    _context.SaveChanges();

                    return Ok();
                }
            }

            return BadRequest();
        }   

    }

}
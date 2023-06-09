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



       [HttpPut]
        public IActionResult BookUpdate([FromBody] Books books)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == books.UserId);
            if (userInDb != null && ModelState.IsValid)
            {
                books.User = userInDb;
                _context.Books.Update(books);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
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

    }
}

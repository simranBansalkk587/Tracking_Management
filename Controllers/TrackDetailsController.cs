using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Data;
using Tracking_Task.Models;

namespace Tracking_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TrackDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateTrackDetails([FromBody] TrackData trackData)
        {
            try
            {
                var previousBook = _context.Books.FirstOrDefault(b => b.Id == trackData.BooksId);
                var newTrackDetails = new TrackData
                {
                    BooksId = trackData.BooksId,
                    Books = previousBook,
                    Change = trackData.Change,
                    Trackingdate = DateTime.Now
                };
                _context.TrackData.Add(newTrackDetails);
                _context.SaveChanges();
                return Ok("TrackDetails created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create TrackDetails: {ex.Message}");
            }
        }
        //[HttpGet("{id}")]
        //public IActionResult GetTrackDetails(int id)
        //{
        //    try
        //    {
        //        var trackDetails = _context.TrackData.FirstOrDefault(td => td.Id == id);

        //        if (trackDetails == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(trackDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Failed to retrieve TrackDetails: {ex.Message}");
        //    }
        //}

        [HttpGet]
        public IActionResult getall()
            {
            var allBooks = _context.TrackData.Include(u => u.Books).Include(u => u.Books.User).ToList();



            return Ok(allBooks);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var getid = _context.TrackData.Include(x => x.Books.User).Where(x => x.Books.UserId == id).ToList();

            return Ok(getid);
        }


    }
}

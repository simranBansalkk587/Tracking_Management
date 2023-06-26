using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class InvitedTableController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public InvitedTableController(ApplicationDbContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InivitedTable>>> GetInvitedTables()
        {
            var invitedTables = await _Context.InivitedTables.Include(i => i.User).ToListAsync();

            return Ok(invitedTables);
        }
       
        [HttpGet("{id}")]
        public IActionResult GetId(int id)

        {
            var getid = _Context.InivitedTables.Include(x => x.User).Where(x => x.UserId == id).ToList();
            // var getid = _context.Users.FirstOrDefault(y => y.Id == books.UserId);
            return Ok(getid);
        }

        [HttpPost]
        public IActionResult Post(InivitedTable invitedTable)
        {
            bool userExists = _Context.InivitedTables.Any(u => u.UserId == invitedTable.UserId);
            if (userExists)
            {
                return Conflict("User already invited");
            }

            _Context.InivitedTables.Add(invitedTable);
            _Context.SaveChanges();

            return Ok("InvitedTable created successfully.");
        }





        [HttpPut("{id}/approve")]
       

        public IActionResult ApproveTrack(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }

            var track = _Context.InivitedTables.FirstOrDefault(t => t.Id == id);

            if (track == null)
            {
                return NotFound();
            }

            track.Status = TrackStatus.Approved;
            _Context.SaveChanges();

            return Ok();
            
        }

        [HttpPut("{id}/pending")]
        public IActionResult SetTrackPending(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }
            var track = _Context.InivitedTables.FirstOrDefault(t => t.Id == id);

            if (track == null)
            {
                return NotFound();
            }

            track.Status = TrackStatus.Pending;
            _Context.SaveChanges();

            return Ok();
        }
        [HttpPut("{id}/disable")]
        public IActionResult DisableTrack(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }
            var track = _Context.InivitedTables.FirstOrDefault(t => t.Id == id);

            if (track == null)
            {
                return NotFound();
            }

            track.Status = TrackStatus.Disabled;
            _Context.SaveChanges();

            return Ok();
        }

       
   

    }
}           

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
        public async Task<ActionResult<InivitedTable>> GetInvitedTable(int id)
        {
            var invitedTable = await _Context.InivitedTables .Include(i => i.User).FirstOrDefaultAsync(i => i.Id == id);

            if (invitedTable == null)
            {
                return NotFound();
            }

            return Ok(invitedTable);
        }
        [HttpPost]
        public async Task<ActionResult<InivitedTable>> CreateInvitedTable(InivitedTable invitedTable)
        {
            
            _Context.InivitedTables.Add(invitedTable);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvitedTable), new { id = invitedTable.Id }, invitedTable);
        }
       
        //public IActionResult GetInvitedTableByEmail(string email)
        //{
        //    var invitedTable = _Context.InivitedTables.FirstOrDefault(i => i.Email == email);

        //    if (invitedTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(invitedTable);
        //}
        //[HttpPut("{id}/approve")]
        //public IActionResult ApproveTrack(int id)
        //{
        //    var track = _Context.InivitedTables.FirstOrDefault(t => t.Id == id);

        //    if (track == null)
        //    {
        //        return NotFound();
        //    }

        //    track.Status = TrackStatus.Approved;
        //    _Context.SaveChanges();

        //    return Ok();
        //}
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

        //    [HttpGet("api/invited-tables")]
        //    public IActionResult GetInvitedTableByEmail(string email)
        //    {
        //        var invitedTable = _Context.InivitedTables.FirstOrDefault(i => i.Email == email);

        //        if (invitedTable == null)
        //        {
        //            return NotFound();
        //        }

        //        if (invitedTable.EmailStatus == EmailStatus.Rejected)
        //        {
        //            return BadRequest("Access Denied"); 
        //        }

        //        return Ok(invitedTable);
        //    }
        [HttpGet("api/invited-tables")]
        public IActionResult GetInvitedTableByEmail([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email parameter is required.");
            }

            var invitedTable = _Context.InivitedTables.FirstOrDefault(i => i.Email == email);

            if (invitedTable == null)
            {
                return NotFound();
            }

            if (invitedTable.EmailStatus == EmailStatus.Rejected)
            {
                return BadRequest("Access Denied");
            }

            return Ok(invitedTable);
        }


    }
}

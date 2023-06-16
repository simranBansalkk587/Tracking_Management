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
    public class InivitedPersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InivitedPersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("{inivitedTableId}/add-user")]
        public async Task<IActionResult> AddUserToInivitedTable(int inivitedTableId, [FromBody] User user)
        {
            try
            {
                var inivitedTable = await _context.InivitedTables.FindAsync(inivitedTableId);
                if (inivitedTable == null)
                {
                    return NotFound("InivitedTable not found");
                }

                var invitedPerson = new InivitedPerson
                {
                    Name = user.Name,
                    InivitedTableId = inivitedTableId,
                    InivitedTable = inivitedTable
                };

                _context.InivitedPerson.Add(invitedPerson);
                await _context.SaveChangesAsync();

                return Ok(invitedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the user to the invited table");
            }
        }
        [HttpPost]
        public ActionResult AddInvitedPerson( [FromBody] InivitedPerson invitedPerson)
        {
            InivitedTable invitedTable = _context.InivitedTables.Find();

            if (invitedTable == null)
            {
                return NotFound("InvitedTable not found.");
            }

            invitedPerson.InivitedTable = invitedTable;

            _context.InivitedPerson.Add(invitedPerson);
            _context.SaveChanges();

            return Ok("InvitedPerson added successfully.");
        }
       


        [HttpGet("{inivitedTableId}/invited-persons")]
        public async Task<IActionResult> GetInvitedPersons(int inivitedTableId)
        {
            try
            {
                var invitedPersons = await _context.InivitedPerson
                    .Where(ip => ip.InivitedTableId == inivitedTableId)
                    .ToListAsync();

                if (invitedPersons == null || invitedPersons.Count == 0)
                {
                    return NotFound("No invited persons found for the given inivitedTableId");
                }

                return Ok(invitedPersons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving invited persons");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<InivitedPerson>> GetAllInvitedPersons()
        {
            List<InivitedPerson> invitedPersons = _context.InivitedPerson.ToList();

            if (invitedPersons.Count == 0)
            {
                return NotFound("No invited persons found.");
            }

            return Ok(invitedPersons);
        }
    }
}


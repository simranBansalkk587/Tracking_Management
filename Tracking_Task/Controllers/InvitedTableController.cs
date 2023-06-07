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
            var invitedTables = await _Context.InivitedTables
                .Include(i => i.User)
                .ToListAsync();

            return Ok(invitedTables);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InivitedTable>> GetInvitedTable(int id)
        {
            var invitedTable = await _Context.InivitedTables
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.Id == id);

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

    }
}

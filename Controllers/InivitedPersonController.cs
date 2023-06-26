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
        [HttpGet]
        public ActionResult<IEnumerable<InivitedPerson>> GetInivitedPeople()
        {
            var inivitedPeople = _context.InivitedPerson.ToList();
            return Ok(inivitedPeople);
        }
        [HttpPost]
        public IActionResult CreateInivitePerson([FromBody] InivitedPerson invitedPerson)
        {
            try
            {

                InivitedTable inivitedTable = _context.InivitedTables.Find(invitedPerson.InivitedTableId);
                if (inivitedTable == null)
                {
                    return NotFound("InivitedTable not found");
                }


                _context.InivitedPerson.Add(invitedPerson);
                _context.SaveChanges();

                return Ok(invitedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}

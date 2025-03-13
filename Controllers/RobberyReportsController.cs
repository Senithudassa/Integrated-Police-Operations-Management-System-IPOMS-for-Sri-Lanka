using Microsoft.AspNetCore.Mvc;
using testproj.Data;
using testproj.Models;
using System.Collections.Generic;
using System.Linq;

namespace testproj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobberyReportsController : ControllerBase // Changed to ControllerBase for API
    {
        private readonly ApplicationDbContext _context;

        public RobberyReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RobberyReports
        [HttpGet]
        public ActionResult<IEnumerable<RobberyReport>> GetRobberyReports()
        {
            return _context.RobberyReports.ToList();
        }

        // GET: api/RobberyReports/5
        [HttpGet("{id}")]
        public ActionResult<RobberyReport> GetRobberyReport(int id)
        {
            var robberyReport = _context.RobberyReports.Find(id);
            if (robberyReport == null)
            {
                return NotFound();
            }
            return robberyReport;
        }

        // POST: api/RobberyReports
        [HttpPost]
        public ActionResult<RobberyReport> CreateRobberyReport([FromBody] RobberyReport robberyReport)
        {
            if (robberyReport == null)
            {
                return BadRequest("Invalid data.");
            }

            _context.RobberyReports.Add(robberyReport);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRobberyReport), new { id = robberyReport.Id }, robberyReport);
        }

        // DELETE: api/RobberyReports/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRobberyReport(int id)
        {
            var robberyReport = _context.RobberyReports.Find(id);
            if (robberyReport == null)
            {
                return NotFound();
            }

            _context.RobberyReports.Remove(robberyReport);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

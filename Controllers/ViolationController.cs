using Microsoft.AspNetCore.Mvc;
using testproj.Data;
using testproj.Models;
using System.Collections.Generic;
using System.Linq;
using testproj.Data;

namespace testproj.Controllers
{
    [Route("api/violations")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViolationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Violation>> GetViolations()
        {
            return _context.Violations.ToList();
        }

        [HttpPost]
        public IActionResult ReportViolation([FromBody] Violation violation)
        {
            _context.Violations.Add(violation);
            _context.SaveChanges();
            return Ok(new { message = "Violation reported successfully!" });
        }
    }
}

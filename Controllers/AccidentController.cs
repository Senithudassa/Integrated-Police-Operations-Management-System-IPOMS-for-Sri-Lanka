using Microsoft.AspNetCore.Mvc;
using testproj.Data;
using testproj.Models;
using System.Linq;
using testproj.Data;

namespace testproj.Controllers
{
    [Route("api/accidents")]
    [ApiController]
    public class AccidentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccidentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ReportAccident([FromBody] Accident accident)
        {
            _context.Accidents.Add(accident);
            _context.SaveChanges();
            return Ok(new { message = "Accident reported successfully!" });
        }
    }
}

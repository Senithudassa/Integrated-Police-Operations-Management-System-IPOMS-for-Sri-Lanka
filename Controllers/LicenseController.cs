using Microsoft.AspNetCore.Mvc;
using testproj.Data;
using testproj.Models;
using System.Linq;
using testproj.Data;

namespace ProjectName.Controllers
{
    [Route("api/license")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LicenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{licenseNumber}")]
        public IActionResult VerifyLicense(string licenseNumber)
        {
            var license = _context.Licenses.FirstOrDefault(l => l.LicenseNumber == licenseNumber);
            if (license == null)
                return NotFound(new { message = "License not found" });

            return Ok(new { license.HolderName, license.IsValid });
        }
    }
}

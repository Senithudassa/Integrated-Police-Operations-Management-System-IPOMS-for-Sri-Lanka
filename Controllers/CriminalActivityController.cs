using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testproj;
using testproj.Data; // Add this
using testproj.Models;
// Replace with your actual namespace

namespace testproj.Controllers
{
    public class CriminalActivityController : Controller
    {
        private readonly CriminalActivityContext _context;

        public CriminalActivityController(CriminalActivityContext context)
        {
            _context = context;
        }

        // GET: CriminalActivity
        public async Task<IActionResult> Index()
        {
            return View(await _context.CriminalActivities.ToListAsync());
        }

        // GET: CriminalActivity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CriminalActivity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Location,Date")] CriminalActivity criminalActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criminalActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criminalActivity);
        }

        // Other CRUD actions (Edit, Delete, etc.)
    }
}

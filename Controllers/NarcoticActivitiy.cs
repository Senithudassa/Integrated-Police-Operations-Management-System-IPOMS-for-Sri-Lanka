using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testproj.Data;
using testproj.Models;
using System;

namespace testproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NarcoticActivitiy : ControllerBase
    {
        private readonly AppDbContext _context;

        public NarcoticActivitiy(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/NarcoticActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NarcoticActivity>>> GetNarcoticActivities()
        {
            return await _context.NarcoticActivities.ToListAsync();
        }

        // GET: api/NarcoticActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NarcoticActivity>> GetNarcoticActivity(int id)
        {
            var narcoticActivity = await _context.NarcoticActivities.FindAsync(id);

            if (narcoticActivity == null)
            {
                return NotFound();
            }

            return narcoticActivity;
        }

        // POST: api/NarcoticActivities
        [HttpPost]
        public async Task<ActionResult<NarcoticActivity>> PostNarcoticActivity(NarcoticActivity narcoticActivity)
        {
            _context.NarcoticActivities.Add(narcoticActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNarcoticActivity", new { id = narcoticActivity.Id }, narcoticActivity);
        }

        // PUT: api/NarcoticActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNarcoticActivity(int id, NarcoticActivity narcoticActivity)
        {
            if (id != narcoticActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(narcoticActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarcoticActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/NarcoticActivities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NarcoticActivity>> DeleteNarcoticActivity(int id)
        {
            var narcoticActivity = await _context.NarcoticActivities.FindAsync(id);
            if (narcoticActivity == null)
            {
                return NotFound();
            }

            _context.NarcoticActivities.Remove(narcoticActivity);
            await _context.SaveChangesAsync();

            return narcoticActivity;
        }

        private bool NarcoticActivityExists(int id)
        {
            return _context.NarcoticActivities.Any(e => e.Id == id);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThyFirstClassesController : ControllerBase
    {
        private readonly ThyContext _context;

        public ThyFirstClassesController(ThyContext context)
        {
            _context = context;
        }

        // GET: api/ThyFirstClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThyFirstClass>>> GetThyFirstClasses()
        {
            return await _context.ThyFirstClasses.ToListAsync();
        }

        // GET: api/ThyFirstClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThyFirstClass>> GetThyFirstClass(long id)
        {
            var thyFirstClass = await _context.ThyFirstClasses.FindAsync(id);

            if (thyFirstClass == null)
            {
                return NotFound();
            }

            return thyFirstClass;
        }

        // PUT: api/ThyFirstClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThyFirstClass(long id, ThyFirstClass thyFirstClass)
        {
            if (id != thyFirstClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(thyFirstClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThyFirstClassExists(id))
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

        // POST: api/ThyFirstClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThyFirstClass>> PostThyFirstClass(ThyFirstClass thyFirstClass)
        {
            _context.ThyFirstClasses.Add(thyFirstClass);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetThyFirstClass", new { id = thyFirstClass.Id }, thyFirstClass);
            return CreatedAtAction(nameof(GetThyFirstClass), new { id = thyFirstClass.Id }, thyFirstClass);
        }

        // DELETE: api/ThyFirstClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThyFirstClass(long id)
        {
            var thyFirstClass = await _context.ThyFirstClasses.FindAsync(id);
            if (thyFirstClass == null)
            {
                return NotFound();
            }

            _context.ThyFirstClasses.Remove(thyFirstClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThyFirstClassExists(long id)
        {
            return _context.ThyFirstClasses.Any(e => e.Id == id);
        }
    }
}

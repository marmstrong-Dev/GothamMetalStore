using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gotham.Models;
using Gotham.Tools;

namespace Gotham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetalController : ControllerBase
    {
        private readonly DataContext _context;

        public MetalController(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // Get List of All Available Metals
        [HttpGet("AllMetal")]
        public async Task<ActionResult<Metal>> GetAllMetals([FromQuery] MetalQueryParameters queryParameters)
        {
            IQueryable<Metal> metals = _context.Metals;

            // Filter By Bundle Size
            if (queryParameters.MinSize != null && queryParameters.MaxSize != null)
            {
                metals = metals.Where (
                    m => m.metalBundleSize >= queryParameters.MinSize.Value &&
                    m.metalBundleSize <= queryParameters.MaxSize.Value
                );
            }

            // Filter By Type
            if (!string.IsNullOrEmpty(queryParameters.metalType))
            { metals = metals.Where(m => m.metalType == queryParameters.metalType); }

            // Paginations
            metals = metals
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await metals.ToArrayAsync());
        }

        // Get Individual Metal Record
        [HttpGet("GetMetal/{id}")]
        public async Task<IActionResult> GetMetal(int id)
        {
            var metal = await _context.Metals.FindAsync(id);
            if (metal == null)
            { return NotFound(); }

            return Ok(metal);
        }

        // Add Single Metals Record
        [HttpPost("AddOne")]
        public async Task<ActionResult<Metal>> AddOneMetal([FromBody] Metal metal)
        {
            _context.Metals.Add(metal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetMetal",
                new { id = metal.id },
                metal
            );
        }

        // Update Single Metal Record
        [HttpPut("ModOne/{id}")]
        public async Task<IActionResult> ModMetal([FromRoute] int id, [FromBody] Metal metal)
        {
            if (id != metal.id)
            { return BadRequest(); }

            _context.Entry(metal).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Metals.Find(id) == null)
                { return NotFound(); }

                throw;
            }

            return NoContent();
        }

        // Delete Single Metal Record
        [HttpDelete("DelOne")]
        public async Task<ActionResult<Metal>> DeleteOneMetal([FromRoute] int id)
        {
            var metal = await _context.Metals.FindAsync(id);

            if (metal == null)
            { return NotFound(); }

            _context.Metals.Remove(metal);
            await _context.SaveChangesAsync();

            return metal;
        }
    }
}

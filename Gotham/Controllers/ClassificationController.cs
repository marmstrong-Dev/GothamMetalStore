using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gotham.Models;

namespace Gotham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassificationController(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // Get List of All Available Classifications
        [HttpGet("AllClassification")]
        public async Task<ActionResult<Classification>> GetAllClassifications()
        {
            IQueryable<Classification> classifications = _context.Classifications;

            return Ok(await classifications.ToArrayAsync());
        }

        // Get Individual Classification Record
        [HttpGet("GetClassification/{id}")]
        public async Task<IActionResult> GetClassification(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);
            if (classification == null)
            { return NotFound(); }

            return Ok(classification);
        }

        // Create New Classification Record
        [HttpPost("CreateClassification")]
        public async Task<ActionResult<Classification>> CreateClassification(Classification classification)
        {
            _context.Classifications.Add(classification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassification", new { id = classification.id }, classification);
        }

        // Update Existing Classification Record
        [HttpPut("UpdateClassification/{id}")]
        public async Task<IActionResult> UpdateClassification(int id, Classification classification)
        {
            if (id != classification.id)
            { return BadRequest(); }

            _context.Entry(classification).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete Existing Classification Record
        [HttpDelete("DeleteClassification/{id}")]
        public async Task<IActionResult> DeleteClassification(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);
            if (classification == null)
            { return NotFound(); }

            _context.Classifications.Remove(classification);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

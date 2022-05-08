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
    public class VendorController : ControllerBase
    {
        private readonly DataContext _context;

        public VendorController(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // Get List of All Available Metals
        [HttpGet("AllVendors")]
        public async Task<ActionResult<Vendor>> GetAllVendors()
        {
            IQueryable<Vendor> vendors = _context.Vendors;

            return Ok(await vendors.ToArrayAsync());
        }

        // Get Individual Vendor Record
        [HttpGet("OneVendor/{id}")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            { return NotFound(); }

            return Ok(vendor);
        }

        // Add Single Metals Record
        [HttpPost("AddOne")]
        public async Task<ActionResult<Vendor>> AddOneVendor([FromBody] Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetVendor",
                new { id = vendor.id },
                vendor
            );
        }
    }
}

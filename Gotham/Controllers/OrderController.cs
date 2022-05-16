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
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // Retrieve All Orders
        [HttpGet("AllOrders")]
        public async Task<ActionResult<Order>> GetAllOrders([FromQuery] OrderQueryParameters queryParameters)
        {
            IQueryable<Order> orders = _context.Orders;

            // Filter By Vendor
            if (queryParameters.orderVendor > 0)
            { orders = orders.Where(o => o.vendorId == queryParameters.orderVendor); }

            // Paginations
            orders = orders
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await orders.ToArrayAsync());
        }

        // Retrieve Individual Order By Id
        [HttpGet("GetOrder/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            { return NotFound(); }

            return Ok(order);
        }

        // Create New Order
        [HttpPost("AddOrder")]
        public async Task<ActionResult<Order>> AddOrder([FromBody] Order order)
        {
            _context.Orders.Add(order);

            var modMetal = await _context.Metals.FindAsync(order.metalId);
            modMetal.lastOrdered = order.orderTime;
            modMetal.bundlesOnHand = modMetal.bundlesOnHand + order.orderBatchQuantity;

            if (modMetal.id != order.metalId) 
            { return BadRequest(); }

            _context.Entry(modMetal).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Metals.Find(order.metalId) == null)
                { return NotFound(); }

                throw;
            }

            return CreatedAtAction(
                "GetOrder",
                new { id = order.id },
                order
            );
        }
    }
}

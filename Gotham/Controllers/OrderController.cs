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
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet("AllOrders")]
        public async Task<ActionResult<Order>> GetAllOrders()
        {
            IQueryable<Order> orders = _context.Orders;

            return Ok(await orders.ToArrayAsync());
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            { return NotFound(); }

            return Ok(order);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    public class OrderController: Controller
    {
        private readonly AppDbContext _dbContext;
        public OrderController(AppDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("getOrders")]
        public IEnumerable<Order> GetOrders() => _dbContext.Orders.ToList();
        
        [HttpGet("getOrderById/{id}")]
        public async Task<Order> GetOrderById(int id) {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order != null) return order;
            return null;
        }
    }
}
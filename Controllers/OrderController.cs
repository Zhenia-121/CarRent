using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderController(AppDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public IEnumerable<OrderResource> GetAll() {

            var orders = _dbContext.Orders.Include(o => o.Car).Include(o => o.User).ToList();
            return _mapper.Map<List<OrderResource>>(orders);
        } 

        [HttpGet]
        public IActionResult GetOrders([FromQuery] QueryObject queryObject) {
            var orders = _dbContext.Orders.Include(o => o.Car).Include(o => o.User).AsQueryable();
            if (queryObject != null) {
                // filtering
                if (!String.IsNullOrWhiteSpace(queryObject.Make))
                    orders = orders.Where(o => o.Car.Make == queryObject.Make);
                if (!String.IsNullOrWhiteSpace(queryObject.Model))
                    orders = orders.Where(o => o.Car.Model == queryObject.Model);
                if (!String.IsNullOrWhiteSpace(queryObject.UserName))
                    orders = orders.Where(o => o.User.FirstName == queryObject.UserName);
                if (queryObject.RentStart != null)
                    orders = orders.Where(o => o.RentStart == queryObject.RentStart);
                if (queryObject.RentEnd != null)
                    orders = orders.Where(o => o.RentEnd == queryObject.RentEnd);

                // pagination
                if (queryObject.Page <= 0)
                    queryObject.Page = 1;
                if (queryObject.PageSize <= 0)
                    queryObject.PageSize = 10;
                orders = orders.Skip((queryObject.Page - 1)* queryObject.PageSize).Take(queryObject.PageSize);
            }
            
            var result = new QueryResult<OrderResource>();
            result.TotalItems = _dbContext.Orders.AsNoTracking().Count();
            result.Items =  _mapper.Map<List<OrderResource>>(orders.ToList());
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id) {
            var order = await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Car)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order != null) 
                return Ok(_mapper.Map<OrderResource>(order));
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] SaveOrderResource newOrderResource) {
            if (!ModelState.IsValid)
                return BadRequest();
            Order newOrder = _mapper.Map<SaveOrderResource, Order>(newOrderResource); 
            await _dbContext.Orders.AddAsync(newOrder);
            await _dbContext.SaveChangesAsync();
            return Ok(_mapper.Map<OrderResource>(newOrder));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] SaveOrderResource updatedOrderResource) {
            if (!ModelState.IsValid)
                return BadRequest();
            var updatingOrder = await _dbContext.Orders.FindAsync(id);
            if (updatingOrder == null)
                return NotFound();
            _mapper.Map<SaveOrderResource, Order>(updatedOrderResource, updatingOrder);
            await _dbContext.SaveChangesAsync(); 
            return Ok(_mapper.Map<OrderResource>(updatingOrder));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id) {
              var deletingOrder = await _dbContext.Orders.FindAsync(id);
              if (deletingOrder == null)
                return BadRequest();
              _dbContext.Orders.Remove(deletingOrder);
              await _dbContext.SaveChangesAsync();
              return Ok();
        }
    }
}
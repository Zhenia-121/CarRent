using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    public class CarController: Controller
    {
        private readonly AppDbContext _dbContext;

        public CarController(AppDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet("getCars")]
        public IEnumerable<Car> GetCars() => _dbContext.Cars.ToList();
        
        [HttpGet("getCarById/{id}")]
        public async Task<Car> GetCarById(int id) {
            var car = await _dbContext.FindAsync<Car>(id);
            if (car != null) return car;
            return null;
        }
    }
}
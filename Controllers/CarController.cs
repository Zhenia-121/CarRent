using AutoMapper;
using CarRent.Resources;
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
        private readonly IMapper _mapper;

        public CarController(AppDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCars() {
            var cars = _dbContext.Cars.ToList();
            return Ok(_mapper.Map<List<CarResource>>(cars));
        } 
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id) {
            var car = await _dbContext.FindAsync<Car>(id);
            if (car != null) 
                return Ok(_mapper.Map<CarResource>(car));
            return NotFound();
        }
    }
}
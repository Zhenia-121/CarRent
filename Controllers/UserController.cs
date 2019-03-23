using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private AppDbContext _dbContext { get; set; }
        public UserController(AppDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("getUsers")]
        public IEnumerable<User> GetUsers() => _dbContext.Users.ToList();
        
        [HttpGet("getUserById/{id}")]
        public async Task<User> GetUserById(int id) {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null) return user;
            return null;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly R6StatsContext _context;

        public UsersController(R6StatsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers([FromQuery] string search)
        {
            var users = _context.Users.Include(x => x.Stats).ToList();
            return !string.IsNullOrEmpty(search) ? users.Where(x => x.Username.Contains(search)) : _context.Users.Include(x => x.Stats);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _context.Users.Where(x => x.UserId == id).Include(x => x.Stats);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
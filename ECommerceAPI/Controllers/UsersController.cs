using ECommerceAPI.Data;
using ECommerceAPI.DTO;
using ECommerceAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public UsersController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<Users>> PostUsers(UserDTO userDto)
        {
     
          
            var users = new Users
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            try
            {
                _context.Users.Add(users);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

using DAL;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;

        public UsersController(IUsers users)
        {
            _users = users;
        }

        // פעולה לקבלת כל המשתמשים
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = _users.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching users.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {

            try
            {
                var user = _users.GetUserById(id);
                if (user == null)
                {
                    Log.Warning("User with id {UserId} not found.", id);  
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching user with id: {UserId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

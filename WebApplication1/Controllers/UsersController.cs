using DAL.Reposetoies;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using DAL.DTOs;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // פעולה לקבלת כל המשתמשים
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching users.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {

            try
            {
                var user = _userRepository.GetUserById(id);
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

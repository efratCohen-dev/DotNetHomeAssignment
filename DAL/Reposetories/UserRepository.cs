using DAL.DTOs;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposetoies
{
    public class UserRepository: IUserRepository
    {
        private static readonly List<UserDto> users = new List<UserDto>
        {
            new UserDto { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new UserDto { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
            new UserDto { Id = 3, Name = "Robert Brown", Email = "robert.brown@example.com" }
        };

        public IEnumerable<UserDto> GetAllUsers()
        {
            return users;
        }

        public UserDto GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }
    }
}


using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsers
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}

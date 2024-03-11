using PetConnect.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DataAccess.Repository
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUserByEmailId(string emailId);

        Task<int> AddUser(User user, Address address);

    }
}

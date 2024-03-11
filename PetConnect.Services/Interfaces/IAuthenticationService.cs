using PetConnect.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserServiceModel> LoginAsync(LoginServiceModel loginData);
        Task<int> SignupAsync(UserServiceModel userData);

    }
}

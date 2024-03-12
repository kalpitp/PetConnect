using PetConnect.DataAccess.Models;
using PetConnect.DataAccess.Repository;
using PetConnect.Services.DTOs;
using PetConnect.Services.Interfaces;
using PetConnect.Services.ModelConversion;

namespace PetConnect.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthenticationService(IAuthenticationRepository authRepository, IAdminRepository adminRepository)
        {
            _authRepository = authRepository;
            _adminRepository = adminRepository;
        }

        public async Task<UserServiceModel> LoginAsync(LoginServiceModel loginData)
        {
            try
            {
                UserServiceModel userInfo = null;
                User user = await _authRepository.GetUserByEmailId(loginData.Email);
                if (user != null && loginData.Password == user.Password)
                {
                    userInfo =ModelConvert.UserToUserServiceModel(user);
                    return userInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> SignupAsync(UserServiceModel userData)
        {
            try
            {

                if (await _authRepository.GetUserByEmailId(userData.Email) != null)
                {
                    return -1;
                }
                User user = new()
                {
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Email = userData.Email,
                    Password = userData.Password,
                    PhoneNumber = userData.PhoneNumber
                };

                City city = await _adminRepository.GetCityIdByName(userData.City);
                State state = await _adminRepository.GetStateByName(userData.State);
                Country country = await _adminRepository.GetCountryByName(userData.Country);


                Address userAddress = new()
                {
                    User = user,
                    Address1 = userData.Address,
                    City = city,
                    State = state,
                    Country = country,
                    PostalCode = userData.PostalCode,
                };

                return await _authRepository.AddUser(user, userAddress);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public async Task<UserServiceModel> GetUserByIdAsync(int id)
        {
            try
            {
                UserServiceModel userInfo = null;
                User user = await _adminRepository.GetUserById(id);
                if (user != null)
                {
                    userInfo = ModelConvert.UserToUserServiceModel(user);
                    return userInfo;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}

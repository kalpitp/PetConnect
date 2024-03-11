using PetConnect.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DataAccess.Repository
{
    public interface IAdminRepository
    {
        Task<City> GetCityIdByName(string cityName);
        Task<State> GetStateByName(string stateName);
        Task<Country> GetCountryByName(string countryName);
        Task<User> GetUserById(int id);

    }
}

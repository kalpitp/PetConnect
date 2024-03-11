using Microsoft.EntityFrameworkCore;
using PetConnect.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DataAccess.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PetConnectContext _context;

        public AdminRepository(PetConnectContext context)
        {
            this._context = context;
        }

        public async Task<City> GetCityIdByName(string cityName)
        {
            try
            {
                return await _context.Cities.FirstOrDefaultAsync(e => e.CityName == cityName);

            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while getting city");
            }

            return null;
        }

        public async Task<Country> GetCountryByName(string countryName)
        {
            try
            {
                return await _context.Countries.FirstOrDefaultAsync(e => e.CountryName == countryName);

            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while getting city");
            }
            return null;

        }

        public async Task<State> GetStateByName(string stateName)
        {
            try
            {
                return await _context.States.FirstOrDefaultAsync(e => e.StateName == stateName);

            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while getting city");
            }
            return null;

        }
    }
}

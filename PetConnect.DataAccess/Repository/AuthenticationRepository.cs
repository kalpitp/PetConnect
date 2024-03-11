using Microsoft.EntityFrameworkCore;
using PetConnect.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DataAccess.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly PetConnectContext _context;

        public AuthenticationRepository(PetConnectContext context)
        {
            this._context = context;
        }

        public async Task<int> AddUser(User user, Address address)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.Addresses.AddAsync(address);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while adding user");

            }

            return 0;
        }

        public async Task<User> GetUserByEmailId(string emailId)
        {

            try
            {
                return await _context.Users.Include(u => u.Addresses)
                                            .ThenInclude(u => u.City)
                                            .ThenInclude(u => u.State)
                                            .ThenInclude(u => u.Country)
                                            .FirstOrDefaultAsync(u => u.Email == emailId);

            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while getting user");
            }

            return null;
        }

        public async Task<User> GetUserById(int id)
        {

            try
            {
                return await _context.Users.Include(u => u.Addresses).FirstOrDefaultAsync(u => u.Id == id);

            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while getting user");
            }

            return null;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PetConnect.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DataAccess.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly PetConnectContext _context;

        public PetRepository(PetConnectContext context)
        {
            _context = context;
        }

        public async Task<int> AddPet(Pet pet)
        {
            try
            {
                await _context.Pets.AddAsync(pet);
                return await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while adding pet");
            }

            return 0;

        }

        public async Task<List<Pet>> GetAllPets()
        {
            try
            {
                return await _context.Pets.Where(p => p.IsActive == true).ToListAsync();

            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while getting pets");
            }

            return new List<Pet>();
        }

        public async Task<Pet?> GetPetById(int id)
        {
            try
            {
                return await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while getting pet");
            }

            return null;
        }

        public async Task<int> UpdatePet(Pet pet)
        {
            try
            {
                _context.Pets.Update(pet);
                return await _context.SaveChangesAsync();


            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while updating pet");
            }
            return 0;
        }

        public async Task<int> DeletePet(int id)
        {
            try
            {


                var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);

                if (pet != null)
                {
                    _context.Pets.Remove(pet);
                    return await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while deleting pet");
            }
            return 0;
        }
    }
}

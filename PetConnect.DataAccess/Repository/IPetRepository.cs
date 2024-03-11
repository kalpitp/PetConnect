using PetConnect.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DataAccess.Repository
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllPets();
        Task<Pet?> GetPetById(int id);

        Task<int> AddPet(Pet pet);

        Task<int> UpdatePet(Pet pet);
        Task<int> DeletePet(int id);

    }
}

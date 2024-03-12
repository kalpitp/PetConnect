using PetConnect.DataAccess.Models;
using PetConnect.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Services.Interfaces
{
    public interface IPetService
    {
        Task<List<PetServiceModel>> GetAllPets();
        Task<PetServiceModel> GetPetById(int id);
    }
}

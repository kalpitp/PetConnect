using PetConnect.DataAccess.Models;
using PetConnect.DataAccess.Repository;
using PetConnect.Services.DTOs;
using PetConnect.Services.Interfaces;
using PetConnect.Services.ModelConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Services.Classes
{
    public class PetService : IPetService
    {
        private readonly IAuthenticationRepository _authRepository;
        private readonly IPetRepository _petRepository;

        public PetService(IAuthenticationRepository authRepository, IPetRepository petRepository)
        {
            _authRepository = authRepository;
            _petRepository = petRepository;
        }

        public async Task<List<PetServiceModel>> GetAllPets()
        {
            try
            {
                var pets = await _petRepository.GetAllPets();
                List<PetServiceModel> petList = new List<PetServiceModel>();

                if (pets != null && pets.Any())
                {
                    foreach (var pet in pets)
                    {
                        petList.Add(ModelConvert.PetToPetServiceModel(pet));
                    }

                    return petList;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<PetServiceModel>();
        }

        public async Task<PetServiceModel?> GetPetById(int id)
        {
            try
            {
                var pet = await _petRepository.GetPetById(id);
                
                PetServiceModel petInfo = null;

                if (pet != null )
                {
                    petInfo = ModelConvert.PetToPetServiceModel(pet);
                    return petInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}

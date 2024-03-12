using PetConnect.DataAccess.Models;
using PetConnect.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Services.ModelConversion
{
    public class ModelConvert
    {

        public static UserServiceModel UserToUserServiceModel(User user)
        {
            return new UserServiceModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Addresses.FirstOrDefault()?.Address1,
                City = user.Addresses.FirstOrDefault()?.City?.CityName,
                State = user.Addresses.FirstOrDefault()?.State?.StateName,
                Country = user.Addresses.FirstOrDefault()?.Country?.CountryName,
                PostalCode = user.Addresses.FirstOrDefault()?.PostalCode,
            };
        }

        public static PetServiceModel PetToPetServiceModel(Pet pet)
        {
            return new PetServiceModel()
            {
                Id = pet.Id,
                UserId = pet.UserId,
                UserName = pet.User.FirstName + " " + pet.User.LastName,
                Category = pet.Breed.Category.CategoryName,
                Name = pet.Name,
                ImageUrl= pet.ImageUrl,
                AdoptionPrice= pet.AdoptionPrice,
                BreedName= pet.Breed.BreedName,
                Age= pet.Age,
                Gender= pet.Gender,
                Description= pet.Description,
                AvailableForAdoption= pet.AvailableForAdoption,
                Color= pet.Color,
                PetSize= pet.PetSize,
                Weight= pet.Weight,
                VaccinationStatus= pet.VaccinationStatus,
                IsActive= pet.IsActive,
            };
        }
    
        
    }
}

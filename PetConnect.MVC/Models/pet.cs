namespace PetConnect.MVC.Models
{
    public class Pet
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }
        public string? UserName { get; set; }

        public string? Category { get; set; }

        public string? Name { get; set; } = null!;

        public string? ImageUrl { get; set; } = null!;

        public decimal? AdoptionPrice { get; set; }


        public string? BreedName { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; } = null!;

        public string? Description { get; set; }

        public bool? AvailableForAdoption { get; set; }

        public string? Color { get; set; }

        public string? PetSize { get; set; }

        public decimal? Weight { get; set; }

        public bool? VaccinationStatus { get; set; }

        public bool? IsActive { get; set; }
    }
}


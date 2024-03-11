using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class Pet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int BreedId { get; set; }

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string? Description { get; set; }

    public bool AvailableForAdoption { get; set; }

    public string? Color { get; set; }

    public string? PetSize { get; set; }

    public decimal? Weight { get; set; }

    public bool? IsAltered { get; set; }

    public bool? VaccinationStatus { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; } = new List<AdoptionApplication>();

    public virtual Breed Breed { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

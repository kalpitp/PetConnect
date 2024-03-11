using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class Breed
{
    public int Id { get; set; }

    public string BreedName { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Origin { get; set; }

    public int? AverageLifespan { get; set; }

    public string? AverageSize { get; set; }

    public string? AverageWeight { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}

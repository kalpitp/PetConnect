using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class AdopterDetail
{
    public int Id { get; set; }

    public int? ApplicationId { get; set; }

    public int? NumberOfAdults { get; set; }

    public int? NumberOfChildren { get; set; }

    public bool? HaveOtherPets { get; set; }

    public string? OtherPetsDetails { get; set; }

    public bool? IsAnyoneAllergicToPet { get; set; }

    public string? HomeOwnership { get; set; }

    public string? AdoptionTimeline { get; set; }

    public string? AdoptionMotivation { get; set; }

    public string? PreviousPetExperience { get; set; }

    public virtual AdoptionApplication? Application { get; set; }
}

using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class Address
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Address1 { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public string? PostalCode { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }

    public virtual User? User { get; set; }
}

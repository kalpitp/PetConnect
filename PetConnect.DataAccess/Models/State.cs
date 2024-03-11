using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class State
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country Country { get; set; } = null!;
}

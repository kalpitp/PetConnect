using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class Country
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}

using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public int StateId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual State State { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class AdoptionFinalization
{
    public int Id { get; set; }

    public int? ApplicationId { get; set; }

    public DateTime? FinalizationDate { get; set; }

    public virtual AdoptionApplication? Application { get; set; }
}

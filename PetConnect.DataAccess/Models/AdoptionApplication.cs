using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class AdoptionApplication
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PetId { get; set; }

    public int Status { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AdopterDetail> AdopterDetails { get; set; } = new List<AdopterDetail>();

    public virtual ICollection<AdoptionFinalization> AdoptionFinalizations { get; set; } = new List<AdoptionFinalization>();

    public virtual Pet Pet { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

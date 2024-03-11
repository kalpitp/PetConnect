using System;
using System.Collections.Generic;

namespace PetConnect.DataAccess.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Breed> Breeds { get; set; } = new List<Breed>();
}

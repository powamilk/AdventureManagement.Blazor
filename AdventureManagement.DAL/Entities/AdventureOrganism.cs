using System;
using System.Collections.Generic;

namespace AdventureManagement.DAL.Entities;

public partial class AdventureOrganism
{
    public int Id { get; set; }

    public int? AdventureId { get; set; }

    public int? OrganismId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Adventure? Adventure { get; set; }

    public virtual Organism? Organism { get; set; }
}

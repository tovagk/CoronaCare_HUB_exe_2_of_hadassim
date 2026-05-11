using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public virtual ICollection<Street> Streets { get; } = new List<Street>();
}

using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Street
{
    public int StreetId { get; set; }

    public string? StreetName { get; set; }

    public int? CityId { get; set; }

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();

    public virtual City? City { get; set; }
}

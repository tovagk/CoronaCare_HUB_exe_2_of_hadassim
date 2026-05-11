using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? StreetId { get; set; }

    public string? StreetNumber { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual Street? Street { get; set; }
}
